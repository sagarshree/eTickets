using eTickets.Models;

namespace eTickets.Dto;

public class MovieDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    public Cinema? Cinema { get; set; }
    
    public Producer? Producer { get; set; }


}