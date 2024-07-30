using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Business.Models;
namespace HelloWorld.Business
{
    public class MovieService
    {
        private readonly string connectionString = "Data Source=DESKTOP-HSDSJ4Q\\MSSQLSERVER01;" +
            "Initial Catalog=Movies;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=True;" +
            "Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False";
        public List<Movie> Get()
        {
            string query = "SELECT * FROM Movies ORDER BY Title";
            List<Movie> movies = [];
            using SqlConnection connection = new(connectionString);
            SqlCommand command = new(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
                    Movie movie = new()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Title = reader["Title"].ToString(),
                        WatchedDate = DateTime.Parse(reader["WatchedDate"].ToString()),
                        Seen = bool.Parse(reader["Seen"].ToString()),
                        Plot = reader["Plot"].ToString(),
                        Rating = reader["Rating"] != DBNull.Value ? (int?)int.Parse(reader["Rating"].ToString()) : null,
                    };


#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8601 // Possible null reference assignment.
                    movies.Add(movie);


                }
                return movies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public void Create(Movie movie)
        {
            string query = "INSERT INTO Movies (Title, Plot , WatchedDate, Seen) VALUES (@Title, @Plot, @WatchedDate, @Seen)";
            using SqlConnection connection = new(connectionString);
            SqlCommand command = new(query, connection);

            command.Parameters.Add("@Title", System.Data.SqlDbType.VarChar, 50).Value = movie.Title;
            command.Parameters.Add("@Plot", System.Data.SqlDbType.VarChar).Value = movie.Plot;
            command.Parameters.Add("@WatchedDate", System.Data.SqlDbType.Date, 50).Value = movie.WatchedDate;
            command.Parameters.Add("@Seen", System.Data.SqlDbType.Bit).Value = movie.Seen;

            connection.Open();
            command.ExecuteNonQuery();

        }
        public void Delete(int id)
        {
            string query = $"DELETE FROM MOVIES WHERE id={id}";

            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(query, connection);
            command.ExecuteNonQuery();
        }
        public void Update(Movie movie)
        {
            if (movie.Id <= 0)
                throw new Exception("Id can't be zero or less");
            else
            {
                string query = "UPDATE Movies SET title=@Title, Plot=@Plot,WatchedDate=@WatchedDate,Seen=@Seen where Id=@Id";

                using SqlConnection connection = new(connectionString);
                connection.Open();

                SqlCommand command = new(query, connection);

                command.Parameters.Add("@Title", System.Data.SqlDbType.VarChar, 50).Value = movie.Title;
                command.Parameters.Add("@Plot", System.Data.SqlDbType.VarChar).Value = movie.Plot;
                command.Parameters.Add("@WatchedDate", System.Data.SqlDbType.Date, 50).Value = movie.WatchedDate;
                command.Parameters.Add("@Seen", System.Data.SqlDbType.Bit).Value = movie.Seen;
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = movie.Id;


                command.ExecuteNonQuery();                
            }
        }
    }


}
