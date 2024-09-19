using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTOs;

public record MovieCreateDTO
(
	[property:Required(ErrorMessage = "Title is required")]
	string Title,	
	DateTime WatchedDate,	
	string? Plot,	
	int? Rating,	
	bool Seen,	
	string GenreIds

);