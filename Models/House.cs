

namespace gregslist_csharp.Models
{
  public class House
  {
    public int Id { get; set; }
    public int Sqft { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public double? Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}
