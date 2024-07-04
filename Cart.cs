using System.Collections;

class Cart 
{
    public List<ICartItem> Items { get; }
   
    public double TotalPrice
    {
        get
        {
            double totalPrice = 0;
            foreach (ICartItem item in Items)
            {
                totalPrice += item.Quantity * item.Product.Price;
            }

            return totalPrice;
        }
    }
    public int TotalItems { get => Items.Count(); }


    public void AddToCart(ICartItem cartItem)
    { 
        Items.Add(cartItem);
    }
    public void ConfirmOrder()
    {
        Console.WriteLine("Confirm order (yes/no) : ");
        string userConfirmation = Console.ReadLine().ToLower();

        if (userConfirmation == "yes")
        {
            PrintBill();
        }

    }
    public void PrintBill()
    {
        Console.WriteLine("  ______________________________________________");
        Console.WriteLine(" |                                              |");
        Console.WriteLine(" |   --------------Point Of Sale--------------  |");
        Console.WriteLine(" |                                              |");
        Console.WriteLine(" |                                              |");
        Console.WriteLine($"|    Total items :          {TotalItems}       |");
        Console.WriteLine(" |                                              |");
        Console.WriteLine($"|    Total Price :          {TotalPrice}       |");
        Console.WriteLine(" |                                              |");
        Console.WriteLine(" |______________________________________________|");

        CashProcess();
    }
    public void CashProcess()
    {
        double cashToGive = 0;
        Console.WriteLine("Enter amount : ");
        double cashTaken = double.Parse(Console.ReadLine());
        if (cashTaken > 0 && cashTaken > TotalPrice)
        {
            cashToGive = cashTaken - TotalPrice;
        }
        else
        {
            Console.WriteLine("invalid amount.......");
        }
  
}