namespace burgershack.Models
{
  public class Fry
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Fry(string name, string description, decimal price)
    {
      Name = name;
      Description = description;
      Price = price;
    }
  }
}