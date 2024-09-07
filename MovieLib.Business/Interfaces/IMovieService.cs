using MovieLib.Domain;

namespace MovieLib.Business.Interfaces
{
    public interface IMovieService
    {
		Task<int> Create(Movie movie);
		Task<bool> Delete(int id);
		Task<List<Movie>> Get();
		Task<Movie> Get(int id);
		Task Update(Movie movie);
	}
}