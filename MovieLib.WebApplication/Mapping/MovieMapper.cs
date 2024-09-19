using DTOs;
using MovieLib.Domain;

namespace MovieLib.WebApplication.Mapping;

public static class MovieMapper
{
	public static MovieGetDTO ToMovieGetDTO(Movie movie)
	{
		return new MovieGetDTO(
			Title: movie.Title,
			WatchedDate: movie.WatchedDate,
			Plot: movie.Plot,
			Rating: movie.Rating,
			Seen: movie.Seen,
			GenreNames: movie.GenreNames
		);
	}
	public static Movie ToMovieFromMovieCreateDTO(MovieCreateDTO movie)
	{
		return new Movie
		{
			Title = movie.Title,
			Plot = movie.Plot,
			WatchedDate = movie.WatchedDate,
			Seen = movie.Seen,
			Rating = movie.Rating,
			GenreIds = movie.GenreIds
		};
	}

}
