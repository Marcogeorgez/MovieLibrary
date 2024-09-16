using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieLib.Domain;
using NSubstitute;

namespace MovieLib.Business.Tests;

public class MovieServiceTests
{
	private readonly ILogger<MovieService> _mockLogger;
	private readonly DataContext _dataContext;
	private readonly MovieService _movieService;

	public MovieServiceTests()
	{
		_mockLogger = Substitute.For<ILogger<MovieService>>();
		var options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase(databaseName: "MovieDatabase")
			.Options;
		_dataContext = new DataContext(options);
		_movieService = new MovieService(_mockLogger, _dataContext);
	}

	[Fact]
	public async Task PopulateGenreNames_ShouldMapGenreNamesCorrectly()
	{
		// Arrange
		// Populating Genre
		List<Genre> genre = new List<Genre> {
			new Genre { Id = 1, Name = "Action" },
			new Genre { Id = 2, Name = "Horror" },
			new Genre { Id = 3, Name = "Humor" },
			new Genre { Id = 4, Name = "SciFi" },
			new Genre { Id = 5, Name = "Fantasy" },
			new Genre { Id = 9999, Name = "Default Genre" }
		};

		foreach (var genre_ in genre)
		{
			_dataContext.Genre.Add(genre_);
		}

		await _dataContext.SaveChangesAsync();

		var movie = new Movie
		{
			Id = 2209,
			Plot = "Checking PopulateGenreNames work as intended ( taking genreId number in movie and returning the genre name) instead of numbers.\r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "Up",
			Rating = 7,
			GenreIds = "1,2,3,4,5,9999"
		};

		var movies = new List<Movie> { movie };

		// Act
		await _movieService.PopulateGenreNames(movies);

		// Assert PopulateGenreNames work as intended ( taking genreId number in movie and returning the genre name
		Assert.NotEmpty(movie.GenreNames);
		Assert.Multiple(() =>
		{
			Assert.Equal("Action", movies[0].GenreNames[0]);
			Assert.Equal("Horror", movies[0].GenreNames[1]);
			Assert.Equal("Humor", movies[0].GenreNames[2]);
			Assert.Equal("SciFi", movies[0].GenreNames[3]);
			Assert.Equal("Fantasy", movies[0].GenreNames[4]);
			Assert.Equal("Default Genre", movies[0].GenreNames[5]);
		});
	}

	[Fact]
	public async Task PopulateGenreNames_SingleMovie_ShouldMapGenreNamesCorrectly()
	{
		// Arrange
		List<Genre> genre = new List<Genre> {
			new Genre { Id = 1, Name = "Action" },
			new Genre { Id = 2, Name = "Horror" }
		};
		foreach (var genre_ in genre)
		{
			_dataContext.Genre.Add(genre_);
		};

		await _dataContext.SaveChangesAsync();

		var movie = new Movie
		{
			Id = 1,
			Plot = "Should Work if previous test work \r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "Up",
			Rating = 7,
			GenreIds = "1,2"
		};

		// Act
		await _movieService.PopulateGenreNames(movie);

		// Assert
		Assert.NotEmpty(movie.GenreNames);
		Assert.True(movie.GenreNames.Count > 1);
		Assert.Equal("Action", movie.GenreNames[0]);
		Assert.Equal("Horror", movie.GenreNames[1]);

	}


	[Fact]
	public async Task Get_ShouldReturnAllMovies()
	{
		// Arrange
		var movie = new Movie
		{
			Id = 2,
			Plot = "Exciting.\r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "Return All Movies Test",
			Rating = 7,
			GenreIds = "1,2"
		};

		_dataContext.Movies.Add(movie);
		await _dataContext.SaveChangesAsync();

		// Act
		var result = await _movieService.Get();

		// Assert
		Assert.True(result.Count > 1);
	}

	[Fact]
	public async Task GetById_ShouldReturnMovie()
	{
		// Arrange
		var movie = new Movie
		{
			Id = 3,
			Plot = "78-year-old Carl travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "The Matrix",
			Rating = 7,
			GenreIds = "1,2"
		};
		;
		_dataContext.Movies.Add(movie);
		await _dataContext.SaveChangesAsync();

		// Act
		var result = await _movieService.Get(3);

		// Assert
		Assert.NotNull(result);
		Assert.Equal("The Matrix", result.Title);
	}
	[Fact]
	public async Task Create_ShouldAddMovie()
	{
		// Arrange
		var movie = new Movie
		{
			Id = 4,
			Plot = "78-year-old Carl travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "The Matrix",
			Rating = 7,
			GenreIds = "1,2"
		};

		// Act
		var result = await _movieService.Create(movie);

		// Assert
		Assert.Equal(201, result);
		var createdMovie = await _dataContext.Movies.FindAsync(4);
		Assert.NotNull(createdMovie);
		Assert.Equal("The Matrix", createdMovie.Title);
	}
	[Fact]
	public async Task Delete_ShouldRemoveMovie()
	{
		// Arrange
		var movie = new Movie
		{
			Id = 5,
			Plot = "78-year-old Carl travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "The Matrix",
			Rating = 7,
			GenreIds = "1,2"
		};
		_dataContext.Movies.Add(movie);
		await _dataContext.SaveChangesAsync();

		// Act
		var result = await _movieService.Delete(5);

		// Assert
		Assert.True(result);
		var deletedMovie = await _dataContext.Movies.FindAsync(5);
		Assert.Null(deletedMovie);
	}



	[Fact]
	public async Task Update_ShouldModifyMovie()
	{
		// Arrange
		var movie = new Movie
		{
			Id = 6,
			Plot = "78-year-old Carl travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
			WatchedDate = new DateTime(2009, 05, 29),
			Seen = false,
			Title = "The Matrix",
			Rating = 7,
			GenreIds = "1,2"
		};


		_dataContext.Movies.Add(movie);
		await _dataContext.SaveChangesAsync();

		var updatedMovie = new Movie
		{
			Id = 6,
			Title = "Is It Matrix?",
			Plot = "Who Knows if It is the new matrix or not , maybe we are inside the matrix , are we ? maybe not who knows ?!",
			Seen = true,
			Rating = 8,
			GenreIds = "1,2,3"
		};

		// Act
		await _movieService.Update(updatedMovie);

		// Assert
		var result = await _dataContext.Movies.FindAsync(6);
		Assert.NotNull(result);
		Assert.Equal("Is It Matrix?", result.Title);
		Assert.Equal("Who Knows if It is the new matrix or not , maybe we are inside the matrix , are we ? maybe not who knows ?!", result.Plot);
		Assert.True(result.Seen);
		Assert.Equal(8, result.Rating);
		Assert.Equal("1,2,3", result.GenreIds);

	}

}