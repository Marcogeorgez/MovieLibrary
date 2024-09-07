using MovieLib.Domain;

namespace MovieLib.Business.Interfaces
{
    public interface IMovieService
    {
		Task<int> Create(MovieCreateDto moviee);
		Task<bool> Delete(int id);
		Task<List<Movie>> Get();
		Task<MovieGetDTO> Get(int id);
		Task Update(Movie movie);
	}
}