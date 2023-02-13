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
    string startCurr = CurrencyMenu();
    double startCurrAmt = GetMoneyAmt();

    System.Console.WriteLine("Which currency do you wish to convert to?");
    string destCurr = CurrencyMenu();

    //Converts all currencies to US, to act as an intermediate currency
    double usAmt = ConvertToUs(ref startCurr, startCurrAmt);
    double destCurrAmt = ConvertFromUS(ref destCurr, usAmt);



    System.Console.WriteLine($"You converted from: {startCurr} with {RoundNum(startCurrAmt)}");
    System.Console.WriteLine($"You converted to: {destCurr}, now you have {RoundNum(destCurrAmt)}");
    Pause();
}

static double ConvertToUs(ref string startCurr, double startCurrAmt)
{
    double usAmt = 0;
    switch (startCurr)
    {
        case "1":
            usAmt = CanadianToUs(startCurrAmt);
            startCurr = "Canadian Dollar";
            break;
        case "2":
            usAmt = EuroToUs(startCurrAmt);
            startCurr = "Euro";
            break;
        case "3":
            usAmt = RupeeToUs(startCurrAmt);
            startCurr = "Indian Rupee";
            break;
        case "4":
            usAmt = YenToUs(startCurrAmt);
            startCurr = "Japanese Yen";
            break;
        case "5":
            usAmt = PesoToUs(startCurrAmt);
            startCurr = "Mexican Peso";
            break;
        case "6":
            usAmt = PoundToUs(usAmt);
            startCurr = "British Pound";
            break;
        case "7":
            usAmt = startCurrAmt;
            startCurr = "US";
            break;
        default:
            System.Console.WriteLine("Not a valid option");
            break;

    }
    return usAmt;
}

static double ConvertFromUS(ref string destCurr, double usAmt)
{
    double destCurrAmt = 0;
    switch (destCurr)
    {
        case "1":
            destCurrAmt = UsToCandian(usAmt);
            destCurr = "Canadian Dollar";
            break;
        case "2":
            destCurrAmt = UsToEuro(usAmt);
            destCurr = "Euro";
            break;
        case "3":
            destCurrAmt = UsToRupee(usAmt);
            destCurr = "Indian Rupee";
            break;
        case "4":
            destCurrAmt = UsToYen(usAmt);
            destCurr = "Japanese Yen";
            break;
        case "5":
            destCurrAmt = UsToPeso(usAmt);
            destCurr = "Mexican Peso";
            break;
        case "6":
            destCurrAmt = UsToPound(usAmt);
            destCurr = "Bristish Pound";
            break;
        case "7":
            destCurrAmt = usAmt;
            destCurr = "US";
            break;

    }
    return destCurrAmt;
}


static string CurrencyMenu()
{

    System.Console.WriteLine(@"
    1. Canadian Dollar
    2. Euro
    3. Indian Rupee
    4. Japanese Yen
    5. Mexican Peso
    6. Bristish Pound
    7. US Dollar");
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

static double CanadianToUs(double amt)
{
    return amt / 1.34;
}

static double EuroToUs(double amt)
{
    return amt / .93;
}

static double RupeeToUs(double amt)
{
    return amt / 82.24;
}

static double YenToUs(double amt)
{
    return amt / 131.20;
}

static double PesoToUs(double amt)
{
    return amt / 18.98;
}

static double PoundToUs(double amt)
{
    return amt / .83;
}

static double UsToEuro(double amt)
{
    return amt * .93;
}

static double UsToCandian(double amt)
{
    return amt * 1.34;
}
static double UsToPeso(double amt)
{
    return amt * 18.98;
}
static double UsToPound(double amt)
{
    return amt * .83;
}
static double UsToRupee(double amt)
{
    return amt * 82.24;
}
static double UsToYen(double amt)
{
    return amt * 131.20;
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

static string RoundNum(double num)
{
    return num.ToString("0.00");
}