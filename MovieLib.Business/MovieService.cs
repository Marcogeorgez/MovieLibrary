using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieLib.Business.Interfaces;
using MovieLib.Business.Mapping;
using MovieLib.Domain;

namespace MovieLib.Business;

public class MovieService : IMovieService
{
	private readonly ILogger<MovieService> _logger;
	private readonly DataContext _dataContext;
	public MovieService(ILogger<MovieService> logger, DataContext dataContext)
	{
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_dataContext = dataContext;
	}

	public async Task<List<Movie>> Get()
	{
		List<Movie> movies = await _dataContext.Movies.Include(x => x.Genre).ToListAsync();
		if (movies == null)
			_logger.LogError("The movies list is empty in Get method");
		return movies;
	}
	public async Task<MovieGetDTO> Get(int id)
	{

		MovieGetDTO? movieGetDTO = await _dataContext.Movies
			.Include(movie => movie.Genre)
			.Where(movie => movie.Id == id)
			.Select(movie => MovieMapper.ToMovieGetDTO(movie))
			.SingleOrDefaultAsync();

		if (movieGetDTO == null)
			_logger.LogError("The movies list is empty in Get method");

		return movieGetDTO!;
	}
	public async Task<int> Create(MovieCreateDto _movie)
	{
		try
		{
			var movie = MovieMapper.ToMovieFromMovieCreateDTO(_movie);
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
		var movieToUpdate = await _dataContext.Movies
			.Where(x => x.Id == movie.Id)
			.ExecuteUpdateAsync(setter => setter
			.SetProperty(m => m .Title, movie.Title)
			.SetProperty(m => m .Plot, movie.Plot)
			.SetProperty(m => m .WatchedDate, movie.WatchedDate)
			.SetProperty(m => m .Seen, movie.Seen)
			.SetProperty(m => m.Rating, movie.Rating)
			.SetProperty(m => m .GenreId, movie.GenreId)
		);


		if (movieToUpdate == 0)
		{
			_logger.LogWarning("Attempted to update movie with ID {Id}, but it was not found.", movie.Id);
			throw new KeyNotFoundException($"Movie with ID {movie.Id} not found.");
		}

		_logger.LogInformation("Successfully updated movie with ID {Id}", movie.Id);
	}

}
