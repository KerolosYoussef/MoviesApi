namespace MovieRate.Core.Models;

public class Genre : BaseModel
{
    [MaxLength(100)]
    public string Name { get; set; }
}