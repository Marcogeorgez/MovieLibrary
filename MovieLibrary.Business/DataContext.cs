using HelloWorld.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Business
    {
    public class DataContext: DbContext
    {

        public DbSet<Movie> MoviesEF
        { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string connectionString = "Data Source=DESKTOP-HSDSJ4Q\\MSSQLSERVER01;" +
            "Initial Catalog=Movies;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=True;" +
            "Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 219,
                Plot = "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.",
                WatchedDate = new DateTime(1999, 03, 31),
                Seen = false,
                Title = "The Matrix"
            },
            new Movie()
            {
                Id = 220,
                Plot = "78-year-old Carl Fredricksen travels to Paradise Falls in his house equipped with balloons, inadvertently taking a young stowaway.\r\n\r\n",
                WatchedDate = new DateTime(2009, 05, 29),
                Seen = false,
                Title = "Up"

                }
            );
            }
    }
}
