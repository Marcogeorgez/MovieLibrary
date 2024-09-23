using MovieLib.Domain;

namespace MovieLib.Business.Interfaces
{
	public interface IMovieService
	{
		/// <include file='../../docs.xml' path='doc/members/member[@name="M:MovieService.Create_Movie(Movie)"]/*'/>
		Task<int> Create(Movie movie);

		/// <include file='../../docs.xml' path='doc/members/member[@name="M:MovieService.Delete(System.Int32)"]/*'/>
		Task<bool> Delete(int id);

		/// <include file='../../docs.xml' path='doc/members/member[@name="M:MovieService.Get"]/*'/>
		Task<List<Movie>> Get();

		/// <include file='../../docs.xml' path='doc/members/member[@name="M:MovieService.Get(System.Int32)"]/*'/>
		Task<Movie> Get(int id);

		/// <include file='../../docs.xml' path='doc/members/member[@name="M:MovieService.Update_Movie(Movie)"]/*'/>
		Task Update(Movie movie);

		/// <include file='../../docs.xml' path='doc/members/member[@name="M:MovieService.PopulateGenreNames(System.Collections.Generic.List{Movie})"]/*'/>
		Task PopulateGenreNames(List<Movie> movies);
	}
}