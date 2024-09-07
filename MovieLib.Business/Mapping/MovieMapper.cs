using MovieLib.Domain;

namespace MovieLib.Business.Mapping
{
	public static class MovieMapper
	{
		public static MovieGetDTO ToMovieGetDTO(Movie movie)
		{
			return new MovieGetDTO
			{
				Title = movie!.Title,
				Plot = movie.Plot,
				WatchedDate = movie.WatchedDate,
				Seen = movie.Seen,
				Rating = movie.Rating,
				GenreName = movie.Genre.Name
			};
		}
		public static Movie ToMovieFromMovieCreateDTO(MovieCreateDto movie)
		{
			return new Movie()
			{
				Title = movie.Title,
				Plot = movie.Plot,
				WatchedDate = movie.WatchedDate,
				Seen = movie.Seen,
				Rating = movie.Rating,
				GenreId = movie.GenreId
			};
		}

	}
}
