using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovieLib.Business.Interfaces;
using MovieLib.Domain;

namespace MovieLib.Business
{
	public class MovieService : IMovieService
	{

		private readonly DataContext _dataContext;
		public MovieService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<Movie>> Get()
		{
			List<Movie> movies = await _dataContext.Movies.Include(x => x.Genre).ToListAsync();

			return movies;
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
					Rating = moviee.Rating

				};
				_dataContext.Movies.Add(movie);
				await _dataContext.SaveChangesAsync();
				return 200;
			}
			catch (DbUpdateException ex)
			{
				if( ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
				{
					return 400;
				}
				throw;
			}
		}
		public async Task Delete(int id)
		{

			Movie? movieToDelete = await _dataContext.Movies.SingleOrDefaultAsync(x => x.Id == id)
				?? throw new ArgumentException("Movie not found!");
			_dataContext.Remove(movieToDelete);
			await _dataContext.SaveChangesAsync();


		}
		public async Task Update(Movie movie)
		{

			if (movie.Id <= 0)
			{
				throw new ArgumentException("Invalid movie ID", nameof(movie.Id));
			}
			Movie? movieToUpdate = await _dataContext.Movies.SingleOrDefaultAsync(x => x.Id == movie.Id)
				?? throw new ArgumentException("Doesn't Exist!");
			movieToUpdate.Title = movie.Title;
			movieToUpdate.Plot = movie.Plot;
			movieToUpdate.WatchedDate = movie.WatchedDate;
			movieToUpdate.Seen = movie.Seen;
			await _dataContext.SaveChangesAsync();

		}

	}
}
