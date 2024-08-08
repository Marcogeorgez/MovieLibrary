using System.ComponentModel.DataAnnotations;

namespace MovieLib.WinForms
    {
    public class Movie
        {

        public int Id { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }
        public required DateTime WatchedDate { get; set; }
        public bool Seen { get; set; }
        public int? Rating { get; set; }
        [MaxLength(500)]
        public string? Plot { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public bool Validate(out string validationMessage)
            {

            if (string.IsNullOrWhiteSpace(Title))
                {

                validationMessage = "Title cannot be empty.";
                return false;
                }
            validationMessage = string.Empty;
            return true;
            }
        }
    public class Genre
        {
        public int Id { get; set; }
        public string Name { get; set; }

        }

    }
