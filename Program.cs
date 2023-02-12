string userInput = "";
while (userInput != "3")
{
    userInput = MenuOptions();
    Route(userInput);
}


static string MenuOptions()
{
    System.Console.WriteLine("1. Convert Currencies");
    System.Console.WriteLine("2. Restaurant POS");
    System.Console.WriteLine("3. Exit");
    System.Console.WriteLine("\nPlease enter your choice");
    return Console.ReadLine().ToUpper();
}


static void Route(string userInput)
{
    switch (userInput)
    {
        case "1":
            ConvertCurrency();
            break;
        case "2":
            RestaurantPOS();
            break;
        case "3":
            System.Console.WriteLine("See ya later partner"); //Do something
            break;
        default:
            System.Console.WriteLine("That option does not exist!!");
            Pause();
            break;
    }
}

static void ConvertCurrency()
{
    System.Console.WriteLine("Which currency do you have?");
    string originatingCurrency = CurrencyMenu();
    double originatingCurrencyAmt = GetMoneyAmt();

}
static string CurrencyMenu()
{
    System.Console.WriteLine(@"
    1. Canadian dollar
    2. Euro
    3. Indian Rupee
    4. Japanese Yen
    5. Mexican Peso
    6. Bristish Pound
    7. US Dollars");
    System.Console.WriteLine("\nPlease choose from the options above");
    return Console.ReadLine().ToUpper();
}
static double GetMoneyAmt()
{
    bool validInput = false;
    double amount = 0;
    while (!validInput)
    {
        System.Console.WriteLine("Please enter the amount");
        string userInput = Console.ReadLine();
        try
        {
            amount = double.Parse(userInput);
            validInput = true;
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine("Please emter a number");
            Pause();
        }
    }
    return amount;
}

static void RestaurantPOS()
{
    System.Console.WriteLine("Restaurant POS");
}

static void Pause()
{
    System.Console.WriteLine("\nPress any key ...");
    Console.ReadKey();
    Console.Clear();
}