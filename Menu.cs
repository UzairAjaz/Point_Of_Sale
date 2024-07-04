

class Menu
{
    static Menu()
    {
        products = new List<IProduct>();
    }
    public static List<IProduct> products; // List of Stock
    Cart cart = new Cart();
    public void MainMenu()
    {
        Console.WriteLine("\t\t\t ____________________________________________________________________________________ ");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|         _______________________ (Point Of Sale) _______________________            |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|        1- Admin Login                                                              |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|        2- Purchase Product                                                         |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|____________________________________________________________________________________|");

        Console.Write("Select an option : ");
        int userChoice = int.Parse(Console.ReadLine());

        Process(userChoice);
    }
    public void AdminMenu()  // When admin login selected
    {
        Console.WriteLine("\t\t\t ____________________________________________________________________________________ ");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|         _______________________ (Point Of Sale) _______________________            |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|        1- Add Product                          2- Find Product                     |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|        3- Display Stock                        4- Upadate Stock                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|                                                                                    |");
        Console.WriteLine("\t\t\t|        5- Back To Main Menu                                                        |");
        Console.WriteLine("\t\t\t|____________________________________________________________________________________|");


        Console.Write("Select an option : ");
        int userChoice = int.Parse(Console.ReadLine());

        AdminProcess(userChoice);
    }

    public void Process(int userChoice) // Main process
    {

        if (userChoice == 1)
        {
            Console.Clear();
            Login();
        }
        else if (userChoice == 2)
        {
            if (products.Count() == 0)
            {
                Console.WriteLine("no stock available......");
            }
            else
            {

                // User purchase process
                DisplayStock();

                Console.WriteLine("Select item (id) :");
                double id = double.Parse(Console.ReadLine());
                Console.WriteLine("Quantity to purchase : ");
                double quantityToPurchase = double.Parse(Console.ReadLine());
                var index = products.FindIndex(x => x.Id == id);
                var cartitem = products[index];
                cart.AddToCart(new CartItem(cartitem, quantityToPurchase));

                Console.WriteLine("Do you want to purchase another? (yes/no)");
                string userDecision = Console.ReadLine().ToLower();
                if (userDecision == "yes")
                {
                    cart.AddToCart(new CartItem(cartitem, quantityToPurchase));
                }
                else if (userDecision == "no")
                {
                    cart.ConfirmOrder();
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid input...........");
        }
    }
    public void Login()
    {
        Console.Write("Username : ");
        string userName = Console.ReadLine();
        Console.Write("Pin : ");
        int Pin = int.Parse(Console.ReadLine());

        if (Pin > 999 && Pin < 9999) // Pin check
        {
            Console.Clear();
            AdminMenu();
        }
        else
        {
            Console.WriteLine("Wrong password..............");
        }
    }
    public void AdminProcess(int userChoice) // Process on products implemented by admin
    {
        switch (userChoice)
        {
            case 1:
                Console.Clear();

                // Product details
                Console.Write("Name : ");
                string name = Console.ReadLine();
                Console.Write("Id : ");
                double id = double.Parse(Console.ReadLine());
                Console.Write("Stock : ");
                double stock = double.Parse(Console.ReadLine());
                Console.Write("Price : ");
                double price = double.Parse(Console.ReadLine());

                var product = new Product() { Id = id, Name = name, Stock = stock, Price = price };

                // Adding product to list 
                Add(product);
                Console.WriteLine("Product added...........");

                ClearMenu();
                break;
            case 2:
                Console.Clear();

                Console.Write("Name : ");
                string productToFind_Name = Console.ReadLine();

                FindProduct(productToFind_Name);
                ClearMenu();
                break;
            case 3:
                DisplayStock();
                ClearMenu();
                break;
            case 4:
                Console.Write("Name : ");
                string productToUpdate_Name = Console.ReadLine();
                Console.Write("Quantity : ");
                double quantity = double.Parse(Console.ReadLine());

                UpdateQuantity(productToUpdate_Name, quantity);
                ClearMenu();
                break;
            case 5:
                MainMenu();
                break;
            default:
                Console.WriteLine("invalid choice............");
                MainMenu();
                break;
        }
    }
    public void Add(IProduct product)
    {
        products.Add(product);
    }

    public void FindProduct(string name)
    {
        var productFound = products.Exists(x => x.Name == name);
        var index = products.FindIndex(x => x.Name == name);

        if (productFound)
        {
            // Display product
            ShowProduct(index);
        }
        else
        {
            Console.WriteLine("Product not found.......");
        }
    }

    public void DisplayStock()
    {
        Console.WriteLine("\n\t\t\t#num -Name - Id - Stock - Price ");

        // Show number line of products

        foreach (IProduct product in products)
        {
            Console.WriteLine($"\n\t\t\t{product.Name} - {product.Id} - {product.Stock} - {product.Price}");
        }

    }
    public void UpdateQuantity(string name, double quantity)
    {
        var index = products.FindIndex(x => x.Name == name);
        products[index].Stock = quantity;

        ShowProduct(index);
    }
    public void ShowProduct(int index)   // Display products 
    {
        Console.WriteLine("\n\t\t\tName - Id - Stock - Price ");
        Console.WriteLine($"\n\t\t\t{products[index].Name} - {products[index].Id} - {products[index].Stock} - {products[index].Price}");
    }
    public void ClearMenu() // Clearing console
    {
        Console.ReadKey();
        Console.Clear();
        AdminMenu();
    }
}


