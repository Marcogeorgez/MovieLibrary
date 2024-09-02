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

		public List<Movie> Get()
		{
			List<Movie> movies = _dataContext.Movies.Include(x => x.Genre).ToList();

			return movies;
		}


		public void Create(Movie movie)
		{
			_dataContext.Movies.Add(movie);
			_dataContext.SaveChanges();

		}
		public void Create(MovieCreateDto moviee)
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
			_dataContext.SaveChanges();

		}
		public void Delete(int id)
		{

			Movie? movieToDelete = _dataContext.Movies.SingleOrDefault(x => x.Id == id)
				?? throw new ArgumentException("Movie not found!");
			_dataContext.Remove(movieToDelete);
			_dataContext.SaveChanges();


		}
		public void Update(Movie movie)
		{

			if (movie.Id <= 0)
			{
				throw new ArgumentException("Invalid movie ID", nameof(movie.Id));
			}
			Movie? movieToUpdate = _dataContext.Movies.SingleOrDefault(x => x.Id == movie.Id)
				?? throw new ArgumentException("Doesn't Exist!");
			movieToUpdate.Title = movie.Title;
			movieToUpdate.Plot = movie.Plot;
			movieToUpdate.WatchedDate = movie.WatchedDate;
			movieToUpdate.Seen = movie.Seen;
			_dataContext.SaveChanges();

		}

	}
}
