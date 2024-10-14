namespace YourProjectNamespace.Models
{
    public class ProductModel
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Calculated Subtotal property
    public decimal Subtotal => Price * Quantity;
}
}