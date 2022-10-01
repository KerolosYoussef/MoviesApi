namespace MovieRate.Core.Models;

public class Movie : BaseModel
{
    public string Title { get; set; }
    public int Year { get; set; }
    [MaxLength(250)]
    public string Storyline { get; set; }
    public byte[] Poster { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}