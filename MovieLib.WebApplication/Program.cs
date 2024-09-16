using DTOs;
using Microsoft.EntityFrameworkCore;
using MovieLib.Business;
using MovieLib.Business.Interfaces;
using MovieLib.Domain;
using MovieLib.WebApplication.Mapping;
using MovieLib.WebApplication.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddLogging();
	builder.Logging.AddConsole();

	builder.Services.AddEndpointsApiExplorer();

	builder.Services.AddSwaggerGen();

	builder.Services.AddDbContext<DataContext>(options 
		=> options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);


	builder.Services.AddScoped<IMovieService, MovieService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	// UseRequestTiming is for measuring the time of each request if in development mode.
	app.UseRequestTiming();
}

app.UseHttpsRedirection();
app.MapPost("/api/movies", async (IMovieService movieService, MovieCreateDTO movieDto) =>
{
	try
	{
		
		Movie movie = MovieMapper.ToMovieFromMovieCreateDTO(movieDto);
		int results = await movieService.Create(movie);

		return results switch
		{
			201 => Results.Created($"/api/movies/{movieDto}", movieDto),
			400 => Results.BadRequest("A movie with similar name exists already!"),
			_ => Results.StatusCode(500)
		};

	}
	catch (Exception ex)
	{
		return Results.BadRequest($"Internal server error: {ex.Message}");
	}
});

app.MapGet("/api/movies", async (IMovieService movieService) =>
{
	List<Movie> movies = await movieService.Get();
	return Results.Ok(movies);
});

app.MapGet("/api/movies/{id}", async (IMovieService movieService, int id) =>
{
	var movie = await movieService.Get(id);
	if (movie == null)
		return Results.NotFound();
	var movieGetDTO = MovieMapper.ToMovieGetDTO(movie);
	return Results.Ok(movieGetDTO);
});

app.MapPut("/api/movies/{id}", async (IMovieService movieService, int id, MovieCreateDTO movieDTO) =>
{
	var movie = MovieMapper.ToMovieFromMovieCreateDTO(movieDTO);
	await movieService.Update(movie);
	return Results.NoContent();
});

app.MapDelete("/api/movies/{id}", async (IMovieService movieService, int id) =>
{
	var isDeleted = await movieService.Delete(id);
	if (!isDeleted)
	{
		return Results.Json(new { message = "This movie doesn't exist!" }, statusCode: 404);
	}
	return Results.NoContent();
});

app.Run();
