using Microsoft.EntityFrameworkCore;
using MovieLib.Domain;

namespace MovieLib.Business
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}


		public virtual DbSet<Movie> Movies { get; set; }
		public DbSet<Genre> Genre { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().Property(x => x.GenreId).HasDefaultValue(1); // To Fix the issue where GenreId has no value.
			modelBuilder.Entity<Movie>().HasIndex(m => m.Title).IsUnique();

			modelBuilder.Entity<Movie>().HasData(new Movie()
			{
				Id = 2199,
				Plot = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
				WatchedDate = new DateTime(1999, 03, 31),
				Seen = false,
				Title = "The Matrix",
				GenreId = 2,
				Rating = 9
			},
			new()
			{
				Id = 2209,
				Plot = "78-year-old Carl travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
				WatchedDate = new DateTime(2009, 05, 29),
				Seen = false,
				Title = "Up",
				Rating = 7,
				GenreId = 3
			}
			);

			modelBuilder.Entity<Genre>().HasData(new Genre()
			{
				Id = 1,
				Name = "Action"
			},
			new()
			{
				Id = 2,
				Name = "Horror"
			},
			new()
			{
				Id = 3,
				Name = "Humor"
			},
			new()
			{
				Id = 4,
				Name = "SciFi"
			},
			new()
			{
				Id = 5,
				Name = "Fantasy"
			}

			);
		}
	}
}
