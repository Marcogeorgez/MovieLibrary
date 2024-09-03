using MovieLib.Domain;

namespace MovieLib.Business.Interfaces
{
    public interface IMovieService
    {
		Task<int> Create(MovieCreateDto moviee);
		Task Delete(int id);
		Task<List<Movie>> Get();
		Task Update(Movie movie);
	}
}