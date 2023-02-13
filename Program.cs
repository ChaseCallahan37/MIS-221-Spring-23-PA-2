
//Main flow of control
string userInput = "";
while (userInput != "3")
{
    userInput = MenuOptions();
    Route(userInput);
}

//Prompts user for what their main menu option choice is
static string MenuOptions()
{
    System.Console.WriteLine("1. Convert Currencies");
    System.Console.WriteLine("2. Restaurant POS");
    System.Console.WriteLine("3. Exit");
    System.Console.WriteLine("\nPlease enter your choice");
    return Console.ReadLine().ToUpper();
}

//Main menu route, handles error checking as well
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

//Method responsible for flow of control for currency converter
static void ConvertCurrency()
{

    //Get the currency the user has and the amount
    System.Console.WriteLine("Which currency do you have?");
    string startCurr = CurrencyMenu();
    double startCurrAmt = GetMoneyAmt();

    //Obtain the desired destination currency
    System.Console.WriteLine("Which currency do you wish to convert to?");
    string destCurr = CurrencyMenu();

    //Converts all currencies to US, to act as an intermediate currency
    //Both convert to and from us receive startCurr as a ref as it is changed from the menu option to the actual currency name
    //EX: 3 entered into startCurr at initialization will be converted to Indian Rupee
    double usAmt = ConvertToUs(ref startCurr, startCurrAmt);

    //Once currency is converted to US amount, then convert from us to destCurrency
    double destCurrAmt = ConvertFromUS(ref destCurr, usAmt);

    System.Console.WriteLine($"You converted from: {startCurr} with {RoundNum(startCurrAmt)}");
    System.Console.WriteLine($"You converted to: {destCurr}, now you have {RoundNum(destCurrAmt)}");
    Pause();
}

static double ConvertToUs(ref string startCurr, double startCurrAmt)
{
    //Test for which currency should be converted to US dollars, methods listed below responsible for conversions
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

//Test for which currency should be converted from US dollars, methods listed below responsible for conversions
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

//receives input from user and tests to see if it is a valid menu option chosen from currency list
static string CurrencyMenu()
{
    bool validInput = false;
    string userInput = "";
    while(!validInput){
        validInput = true;
        System.Console.WriteLine(@"
    1. Canadian Dollar
    2. Euro
    3. Indian Rupee
    4. Japanese Yen
    5. Mexican Peso
    6. Bristish Pound
    7. US Dollar");
    System.Console.WriteLine("\nPlease choose from the options above");
    userInput = Console.ReadLine().ToUpper();
    if(
        userInput != "1" &&
        userInput != "2" &&
        userInput != "3" &&
        userInput != "4" &&
        userInput != "5" &&
        userInput != "6" &&
        userInput != "7"
        )  {
        validInput = false;
        System.Console.WriteLine("Invalid input, please choose from one of the options listed");
            Pause();
        }
    }
    return userInput;
}

//Generic method responsible for returning a double
//If user enters input that cannot be converted to a double,
//then exception will be thrown and caught and user will be prompted to enter valid input
static double GetMoneyAmt()
{
    bool validInput = false;
    double amount = 0;
    while (!validInput)
    {
        System.Console.Write("Amount: ");
        string userInput = Console.ReadLine();
        try
        {
            amount = double.Parse(userInput);
            validInput = true;
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine("Please enter a number");
            Pause();
        }
    }
    return amount;
}

//Methods for conversions to and from USD

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

//Method responsible for flow of control for POS
static void RestaurantPOS()
{
    System.Console.WriteLine("Please enter your food total");
    double foodTotal = GetMoneyAmt();

    System.Console.WriteLine("\nPlease enter your alcohol total");
    double alcoholTotal = GetMoneyAmt();

    //Subtotal needed for generating tax
    double subTotal = foodTotal + alcoholTotal;

    //Add total tax
    double grandTotal = GetTax(subTotal);

    // base tip off of food total before tax
    grandTotal += GetTip(foodTotal);

    System.Console.WriteLine($"Your grand total is ${RoundNum(grandTotal)}\n");

    double changeDue = GetPayment(grandTotal);

    System.Console.WriteLine($"Your change back is ${RoundNum(changeDue)}");
}

static double GetTax(double billTotal){
    return billTotal * 1.09;
}

static double GetTip(double nonAlcoholTotal){
    return nonAlcoholTotal * 1.18;
}

//Receives the amount that the patron owes and tests to see if it is greater than amount paid
//will continue iterating until amount greater than grand total is entered
static double GetPayment(double grandTotal){
    bool validPayment = false;
    double payment = 0;
    while(!validPayment){
        validPayment = true;
        System.Console.WriteLine("Please enter your payment amount");
        payment = GetMoneyAmt();
        if(grandTotal > payment){
            validPayment = false;
            System.Console.WriteLine($"Please enter an amount greater than your amount due (${RoundNum(grandTotal)})");
            Pause();
        }
    }

    return payment - grandTotal;
}

//Stops the program, waits for the user to hit a key, then clears the console
static void Pause()
{
    System.Console.WriteLine("\nPress any key ...");
    Console.ReadKey();
    Console.Clear();
}

//Takes any double and returns a rounded stringified version
static string RoundNum(double num)
{
    return num.ToString("0.00");
}