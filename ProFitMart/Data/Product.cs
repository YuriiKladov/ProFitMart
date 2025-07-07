namespace ProFitMart.Data;

public sealed class Product
{
	public Guid ProductId { get; set; }

	public string ProductName { set; get; }

	public decimal Price { get; set; }

	public DateTime CreatedAt { get; set; }

	public DateTime UpdatedAt { get; set; }
}
