

class Program
{
    public static void Main()
    {
        try
        { 
            Menu menu = new Menu();
            menu.MainMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
       

      

}

