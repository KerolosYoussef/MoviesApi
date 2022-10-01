using System.ComponentModel.DataAnnotations;

namespace MovieRate.API.Dtos;

public class GenreDto
{
    [MaxLength(100)]
    public string Name { get; set; }
}