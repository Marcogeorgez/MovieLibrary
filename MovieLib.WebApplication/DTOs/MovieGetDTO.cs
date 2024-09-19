using System.ComponentModel.DataAnnotations;

namespace DTOs;

public record MovieGetDTO
(
	[property:Required(ErrorMessage = "Title is required")]
	string Title,
	DateTime WatchedDate,
	string? Plot,
	int? Rating,
	bool Seen,
	List<string> GenreNames
);