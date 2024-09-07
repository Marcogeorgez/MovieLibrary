using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieLib.Business.Interfaces;
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
	{MovieGetDTO
		? movieGetDTO = await _dataContext.Movies.Where(movie => movie.Id == id).Select(movie => new MovieGetDTO
		{
			Title = movie!.Title,
			Plot = movie.Plot,
			WatchedDate = movie.WatchedDate,
			Seen = movie.Seen,
			Rating = movie.Rating,
			GenreName = movie.Genre.Name
		}).SingleOrDefaultAsync();
		if (movieGetDTO == null)
			_logger.LogError("The movies list is empty in Get method");
		return movieGetDTO;
	}
	public async Task<int> Create(MovieCreateDto moviee)
	{
		try
		{
			var movie = new Movie()
			{
				Title = moviee.Title,
				Plot = moviee.Plot,
				WatchedDate = moviee.WatchedDate,
				Seen = moviee.Seen,
				Rating = moviee.Rating,
				GenreId = moviee.GenreId
			};
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
			_logger.LogError("Invalid movie id , can't be zero or negative !");
		}
		Movie? movieToUpdate = await _dataContext.Movies.SingleOrDefaultAsync(x => x.Id == movie.Id);
		if (movieToUpdate == null)
		{
			_logger.LogWarning("Attempted to update movie with ID {Id}, but it was not found.", movie.Id);
		}
		movieToUpdate.Title = movie.Title;
		movieToUpdate.Plot = movie.Plot;
		movieToUpdate.WatchedDate = movie.WatchedDate;
		movieToUpdate.Seen = movie.Seen;
		await _dataContext.SaveChangesAsync();

	}

}
