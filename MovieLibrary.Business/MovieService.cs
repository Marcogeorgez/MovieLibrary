using HelloWorld.Business.Models;
namespace HelloWorld.Business
    {
    public class MovieService
    {

        private DataContext dataContext;
        public MovieService()
        {
            dataContext = new DataContext();
        }

        public List<Movie> Get()
        {
            List<Movie> movies = dataContext.MoviesEF.ToList();
            return movies;
        }


        public void Create(Movie movie)
        {
            dataContext.MoviesEF.Add(movie);
            dataContext.SaveChanges();

        }
        public void Delete(int id)
        {
            Movie movieToDelete = dataContext.MoviesEF.Single(x => x.Id == id);

            dataContext.Remove(movieToDelete);
            dataContext.SaveChanges();  
        }
        public void Update(Movie movie)
        {
            if(movie.Id <= 0)
            {
                throw new Exception("Movie cannot exist!!!");
            }
            Movie movieToUpdate = dataContext.MoviesEF.Single(x => x.Id == movie.Id);
            dataContext.Update(movieToUpdate);
            dataContext.SaveChanges();

        }
        
    }
}
