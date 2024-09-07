using System.ComponentModel.DataAnnotations;

namespace MovieLib.Domain
{
	public class MovieGetDTO
	{

		[Required(ErrorMessage = "Title is required")]
		public required string Title { get; set; }
		public DateTime WatchedDate { get; set; }
		public string? Plot { get; set; }
		public int? Rating { get; set; }
		public bool Seen { get; set; }
		public string GenreName { get; set; }

	}
}