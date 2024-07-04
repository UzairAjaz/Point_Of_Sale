
interface IProduct
{
    double Id { get; set; }
    string Name { get; set; }
    double Stock { get; set; }
    double Price { get; set; }
}   

class Product : IProduct
{
    public double Id { get; set; }
    public string Name { get; set; }
    public double Stock { get; set; }
    public double Price { get; set; }


}
interface ICartItem
{
    IProduct Product { get; set; }

    public double Quantity { get; set; }
}
class CartItem : ICartItem
{
    public IProduct Product { get; set; }
    public double Quantity { get; set; }

    public CartItem() { }
    public CartItem(IProduct product, double quantity)
    {
        Product = product;
        Quantity = quantity;
    }

}