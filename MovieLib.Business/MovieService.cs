﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieLib.Business.Interfaces;
using MovieLib.Domain;

namespace MovieLib.Business;

///<inheritdoc/>
public class MovieService : IMovieService
{
	private readonly ILogger<MovieService> _logger;
	private readonly DataContext _dataContext;

	public MovieService(ILogger<MovieService> logger, DataContext dataContext)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_dataContext = dataContext;
	}


	/*
	 Used to Fetch all relevant genres in a single query and store them in a dictionary for quick lookup
	 then iterate through each movie, mapping its genre IDs to genre names using the created dictionary
	 */

	public async Task PopulateGenreNames(List<Movie> movies)
	{
		HashSet<int> allGenreIds = new HashSet<int>(movies
			.SelectMany(m => m.GenreIdList));

		// for fast access to hold genre names instead of querying it for every single movie ,
		// therefore querying it only once and storing them in a temporary dictionary
		Dictionary<int, string> genresDict = await _dataContext.Genre
		.Where(g => allGenreIds.Contains(g.Id))
		.ToDictionaryAsync(g => g.Id, g => g.Name);

		Parallel.ForEach(movies, movie =>
		{
			movie.GenreNames = movie.GenreIdList
				.Select(id => genresDict.TryGetValue(id, out var name) ? name : "Unknown Genre")
				.ToList();
		});
	}

	// for single movie only instead of list of movies.
	public async Task PopulateGenreNames(Movie movie)
	{
		await PopulateGenreNames(new List<Movie> { movie });
	}


	// Return all movies in the db

	public async Task<List<Movie>> Get()
	{
		List<Movie> movies = await _dataContext.Movies
			.ToListAsync();
		if (movies == null)
			_logger.LogError("The movies list is empty in Get method");

		await PopulateGenreNames(movies);
		return movies!;
	}

	// Used to add a single movie
	public async Task<Movie> Get(int id)
	{
		Movie? movie = await _dataContext.Movies
			.Where(movie => movie.Id == id)
			.SingleOrDefaultAsync();

		if (movie == null)
			_logger.LogError("The movies list is empty in Get method");

		await PopulateGenreNames(movie);

		return movie!;
	}


	public async Task<int> Create(Movie movie)
	{
		try
		{
			if (movie == null || string.IsNullOrEmpty(movie.Title))
				return 400;
				
			_dataContext.Movies.Add(movie);
			await _dataContext.SaveChangesAsync();
			return 201;
		}
		catch (DbUpdateException ex)
		{
			if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
			{
				return 400;
			}
			throw new Exception($"An error has occurred: {ex}");
		}
	}

	public async Task<bool> Delete(int id)
	{
		Movie? movieToDelete = await _dataContext.Movies.SingleOrDefaultAsync(x => x.Id == id);
		if (movieToDelete == null)
		{
			_logger.LogWarning("Attempted to delete movie with ID {Id}, but it was not found.", id);
			return false;
		}

		_dataContext.Remove(movieToDelete);
		await _dataContext.SaveChangesAsync();

		_logger.LogInformation("Successfully deleted movie with ID {Id}.", id);
		return true;
	}

	public async Task Update(Movie movie)
	{
		if (movie.Id <= 0)
		{
			_logger.LogError($"Invalid movie id: {movie.Id}. ID must be positive");
			throw new ArgumentException("Movie Id must be positive.", nameof(movie));
		}
		// Check if the database provider is in-memory cause in-memory has no ExecuteUpdateAsync
		if (_dataContext.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
		{
			// In-memory provider: manually update the movie entity
			var movieToUpdate = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
			movieToUpdate.Title = movie.Title;
			movieToUpdate.Plot = movie.Plot;
			movieToUpdate.WatchedDate = movie.WatchedDate;
			movieToUpdate.Seen = movie.Seen;
			movieToUpdate.Rating = movie.Rating;
			movieToUpdate.GenreIds = movie.GenreIds;

			await _dataContext.SaveChangesAsync();
		}
		// Production: uses ExecuteUpdateAsync for efficiency
		else
		{
			// Mapping movie to update relevant information in db
			var movieToUpdate = await _dataContext.Movies
				.Where(x => x.Id == movie.Id)
				.ExecuteUpdateAsync(setter => setter
				.SetProperty(m => m.Title, movie.Title)
				.SetProperty(m => m.Plot, movie.Plot)
				.SetProperty(m => m.WatchedDate, movie.WatchedDate)
				.SetProperty(m => m.Seen, movie.Seen)
				.SetProperty(m => m.Rating, movie.Rating)
				.SetProperty(m => m.GenreIds, movie.GenreIds)
			);

			// checks if nothing is returned from from db
			if (movieToUpdate == 0)
			{
				_logger.LogWarning("Attempted to update movie with ID {Id}, but it was not found.", movie.Id);
				throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");
			}

			_logger.LogInformation("Successfully updated movie with ID {Id}", movie.Id);
		}
	}
}