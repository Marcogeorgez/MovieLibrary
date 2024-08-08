using HelloWorld.Business.Models;
using Microsoft.EntityFrameworkCore;
namespace HelloWorld.Business
    {
    public class MovieService
    {

        public DataContext dataContext;
        public MovieService()
        {
            dataContext = new DataContext();
        }

        public List<Movie> Get()
        {
            List<Movie> movies = dataContext.Movies.Include(x => x.Genre).ToList();

            return movies;
        }


        public void Create(Movie movie)
        {
            dataContext.Movies.Add(movie);
            dataContext.SaveChanges();

        }
        public void Delete(int id)
        {

            Movie? movieToDelete = dataContext.Movies.SingleOrDefault(x => x.Id == id)
                ?? throw new ArgumentException("Movie not found!");
            dataContext.Remove(movieToDelete);
            dataContext.SaveChanges();

            
        }
        public void Update(Movie movie)
        {

            if(movie.Id <= 0)
            {
                throw new ArgumentException("Invalid movie ID", nameof(movie.Id));
            }
            Movie? movieToUpdate = dataContext.Movies.SingleOrDefault(x => x.Id == movie.Id) 
                ?? throw new ArgumentException("Doesn't Exist!");
            movieToUpdate.Title = movie.Title;
            movieToUpdate.Plot = movie.Plot;
            movieToUpdate.WatchedDate = movie.WatchedDate;
            movieToUpdate.Seen = movie.Seen;
            dataContext.SaveChanges();

        }
        
    }
}
