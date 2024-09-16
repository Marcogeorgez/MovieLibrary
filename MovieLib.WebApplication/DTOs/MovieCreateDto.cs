using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs;

public class MovieCreateDTO
{
	[Required(ErrorMessage = "Title is required")]
	public required string Title { get; set; }
	public DateTime WatchedDate { get; set; }
	public string? Plot { get; set; }
	public int? Rating { get; set; }
	public bool Seen { get; set; }
	public string GenreIds { get; set; }

}