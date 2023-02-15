
var assistantFunctions = new AssistantFunctions();
var expensesMenu = new ExpensesMenu();

var users = new List<User>();
var expenses = new List<Expenses>();

bool isFalse = true;

MainFunction();

void MainFunction()
{
    Console.Clear();
    while (isFalse)
    {
        expensesMenu.MinMenu();
        var input = assistantFunctions.CorrectReturn_Int("Your choise");

        switch (input)
        {
            case 1: SignUp(); break;
            case 2: SignIn(); break;
            case 3: ShowUsers(); break;
            case 4: isFalse = false; break;
        }
    }
}


void SignUp()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to SIGN UP\n");

    Console.Write("Login: ");
    var login = Console.ReadLine();
    Console.Write("Password: ");
    var password = Console.ReadLine();

    var user = new User();
    user.SaveNewUser(login, password);

    users.Add(user);
    assistantFunctions.Loading("New user added");
}

void SignIn()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to SIGN IN\n");

    Console.Write("Login: ");
    var login = Console.ReadLine();
    Console.Write("Password: ");
    var password = Console.ReadLine();

    if (CheckUsers(users, login!, password!))
    {
        SignInFunction(login!);
    }
    else
    {
        assistantFunctions.ColorTextRed("Invalid login or password! ");
        assistantFunctions.PressEnter();
        MainFunction();
    }
}

void SignInFunction(string userLogin)
{
    Console.Clear();
    assistantFunctions.ColorTextYellow($"\t\tWelcome: {userLogin} \n");

    while (true)
    {
        expensesMenu.Expenses_Menu();
        var input = assistantFunctions.CorrectReturn_Int("Your Choise");

        switch (input)
        {
            case 1: AddExpenses(userLogin); break;
            case 2: ShowExpenses(); break;
            case 3: Conculate(); break;
            case 4: MainFunction(); break;
        }
    }
}

void AddExpenses(string userLogin)
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to ADD EXPENSES\n");
    Console.WriteLine("User: " + userLogin);

    Console.Write("Product name: ");
    string? productName = Console.ReadLine();

    int productPrice = assistantFunctions.CorrectReturn_Int("Product price");

    var newExpenses = new Expenses();
    newExpenses.SaveExpenses(productName!, productPrice, userLogin);

    expenses.Add(newExpenses);
    assistantFunctions.Loading("New product added");
}

void ShowExpenses()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to SHOW EXPENSES\n");

    for (int i = 0; i < expenses.Count; i++)
    {
        Console.Write($"{i + 1}. ");
        expenses[i].ShowUsers(expenses[i].UserLogin, expenses[i].ProductName, expenses[i].ProductPrice);
    }
    assistantFunctions.PressEnter();
}


void Conculate()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to CONCULATE \n");

    var totalExpensesSum = expenses.Sum(ex => ex.ProductPrice);
    var avarageSumma = totalExpensesSum / users.Count;

    Console.WriteLine($"Total expenses sum: {totalExpensesSum} " +
                        $"\nUser count: {users.Count} " +
                        $"\nAvarage summa: {avarageSumma}");

    ConsoleColor defaultColor = Console.BackgroundColor;

    Console.ForegroundColor = ConsoleColor.Green;
    foreach (var user in users)
    {
        var userSum = expenses.Where(ex => ex.UserLogin == user.Login).Sum(ex => ex.ProductPrice);

        Console.WriteLine($"User login: {user.Login},  User sum: {userSum},  Price difference: {avarageSumma - userSum}");
    }
    defaultColor = Console.BackgroundColor;
}



bool CheckUsers(List<User> users, string login, string password)
{
    return users.Any(user => user.Login == login && user.Password == password);
}


void ShowUsers()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to SHOW USERS\n");

    for (int i = 0; i < users.Count; i++)
    {
        Console.WriteLine($"{i + 1}. User name: {users[i].Login}");
    }
}
