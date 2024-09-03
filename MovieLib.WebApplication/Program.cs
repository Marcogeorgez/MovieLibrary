using Microsoft.EntityFrameworkCore;
using MovieLib.Business;
using MovieLib.Business.Interfaces;
using MovieLib.Domain;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
	builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
	builder.Services.AddScoped<IMovieService, MovieService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/movies", async (IMovieService movieService, MovieCreateDto movieDto) =>
{
	try
	{
		int results = await movieService.Create(movieDto);

		return results switch
		{
			200 => Results.Created($"/api/movies/{movieDto}", movieDto),
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
app.MapPut("/api/movies/{id}", async (IMovieService movieService, int id, Movie movie) =>
{
	movie.Id = id;
	await movieService.Update(movie);
	return Results.NoContent();
});
app.MapDelete("/api/movies/{id}", async (IMovieService movieService, int id) =>
{
	await movieService.Delete(id);
	return Results.NoContent();
});

app.Run();
