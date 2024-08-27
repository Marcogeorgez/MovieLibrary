using MovieLib.Domain;
using Microsoft.EntityFrameworkCore;
using MovieLib.Business.Interfaces;
using MovieLib.Business;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer("Data Source=DESKTOP-HSDSJ4Q\\MSSQLSERVER01;" +
			"Initial Catalog=Movies;" +
			"Integrated Security=True;" +
			"Connect Timeout=30;" +
			"Encrypt=True;" +
			"Trust Server Certificate=True;" +
			"Application Intent=ReadWrite;" +
			"Multi Subnet Failover=False"), ServiceLifetime.Transient);
builder.Services.AddScoped<IMovieService, MovieService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/movies", (IMovieService movieService) =>
{
	List<Movie> movies = movieService.Get();
	return Results.Ok(movies);
});
app.MapDelete("/api/movies/{id}", (IMovieService movieService, int id) =>
{
	movieService.Delete(id);
	return Results.NoContent();
});
app.MapPost("/api/movies", (IMovieService movieService, MovieCreateDto movieDto) =>
{
	movieService.Create(movieDto);
	return Results.NoContent();
});
app.MapPut("/api/movies/{id}", (IMovieService movieService, int id, Movie movie) =>
{
	movie.Id = id;
	movieService.Update(movie);
	return Results.NoContent();
});
app.Run();
