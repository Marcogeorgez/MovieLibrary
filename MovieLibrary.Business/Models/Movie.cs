using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Business.Models
{

    public class Movie
    {
        public  int Id { get; set; }
        public required string Title { get; set; }
        public required DateTime DateWatched { get; set; }
        public bool Seen { get; set; }
        public  int? Rating { get; set; }
        public string? Plot { get; set; }

    }
}
