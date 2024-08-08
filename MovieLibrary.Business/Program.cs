using HelloWorld.Business.Models;
using System.Text.Json;

Console.WriteLine("Working");

List<Movie> movies = new();
using (HttpClient client = new())
    {
    HttpResponseMessage response = await client.GetAsync("https://localhost:7065/api/movies");
    if (response.IsSuccessStatusCode)
        {
        Console.WriteLine(response.Content);    
        string content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
            {
            PropertyNameCaseInsensitive = true
            };
        movies = JsonSerializer.Deserialize<List<Movie>>(content,options) ?? throw new Exception("Movies are null");
        }
    else
        throw new Exception($"Status code isn't right !! it isn't success , check it, Response Code is:{response.StatusCode}");

}
foreach(Movie movie in movies)
    {
    Console.WriteLine($"{movie.Id}");
    Console.WriteLine($"{movie.Title}");
    Console.WriteLine($"{movie.WatchedDate}");
    Console.WriteLine($"{movie.Seen}");
    Console.WriteLine($"{movie.Rating}");
    Console.WriteLine($"{movie.Plot}");
    Console.WriteLine($"{movie.GenreId}");
    Console.WriteLine($"{movie.Genre.Name}");
    Console.WriteLine("-----------------------------------------------------------------\n\n\n");


    }

