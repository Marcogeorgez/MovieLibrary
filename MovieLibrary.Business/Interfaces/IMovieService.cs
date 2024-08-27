using MovieLib.Domain;

namespace MovieLib.Business.Interfaces
{
    public interface IMovieService
    {
        void Create(Movie movie);
        void Create(MovieCreateDto movieCreateDto);
        void Delete(int id);
        List<Movie> Get();
        void Update(Movie movie);
    }
}