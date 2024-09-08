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
			modelBuilder.Entity<Genre>()
				.HasData(
				new Genre { Id = 1, Name = "Action" },
				new Genre { Id = 2, Name = "Horror" },
				new Genre { Id = 3, Name = "Humor" },
				new Genre { Id = 4, Name = "SciFi" },
				new Genre { Id = 5, Name = "Fantasy" },
				new Genre { Id = 9999, Name = "Default Genre" }
				);

			modelBuilder.Entity<Movie>().HasIndex(m => m.Title).IsUnique();

			modelBuilder.Entity<Movie>().HasData(new Movie()
			{
				Id = 2199,
				Plot = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
				WatchedDate = new DateTime(1999, 03, 31),
				Seen = false,
				Title = "The Matrix",
				Rating = 9,
				GenreIds = "1,3,5"
			},
			new()
			{
				Id = 2209,
				Plot = "78-year-old Carl travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
				WatchedDate = new DateTime(2009, 05, 29),
				Seen = false,
				Title = "Up",
				Rating = 7,
				GenreIds = "1,2"
			}
			);
		}
	}
}
