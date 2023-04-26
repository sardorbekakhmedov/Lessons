var users = new List<User>();
var outlays = new List<Outlay>();


var outlayMenu = new OutlayMenu();
var assistantFunctions = new AssistantFunctions();
bool isFalse = true;

MainFunction();

void MainFunction()
{
    Console.Clear();
    while (isFalse)
    {
        outlayMenu.MinMenu();
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


    if (!CheckLogin (users, login!))
    {
        var user = new User();
        user.SaveNewUser(login, password);

        users.Add(user);
        assistantFunctions.Loading("New user added");
    }
    else
    {
        Console.WriteLine("Invalid login");
        assistantFunctions.PressEnter();
        SignUp();
    }
}

bool CheckLogin(List<User> users, string login)
{
    return users.Any(user => user.Login == login);
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
        outlayMenu.Outlay_Menu();
        var input = assistantFunctions.CorrectReturn_Int("Your Choise");

        switch (input)
        {
            case 1: Addoutlays(userLogin); break;
            case 2: Showoutlays(); break;
            case 3: Conculate(); break;
            case 4: MainFunction(); break;
        }
    }
}

void Addoutlays(string userLogin)
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to ADD outlays\n");
    Console.WriteLine("\t\tUser: " + userLogin);

    Console.Write("Product name: ");
    string? productName = Console.ReadLine();

    int productPrice = assistantFunctions.CorrectReturn_Int("Product price");

    var newoutlays = new Outlay();
    newoutlays.SaveOutlay (productName!, productPrice, userLogin);

    outlays.Add(newoutlays);
    assistantFunctions.Loading("New product added");
}

void Showoutlays()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to SHOW outlays\n");

    for (int i = 0; i < outlays.Count; i++)
    {
        Console.Write($"{i + 1}. ");
        outlays[i].ShowOutlay (outlays[i].UserLogin, outlays[i].ProductName, outlays[i].ProductPrice);
    }
    assistantFunctions.PressEnter();
}


void Conculate()
{
    Console.Clear();
    assistantFunctions.ColorTextYellow("\t\tWelcome to CONCULATE \n");

    var totaloutlaysSum = outlays.Sum(ex => ex.ProductPrice);
    var avarageSumma = totaloutlaysSum / users.Count;

    Console.WriteLine($"Total outlays sum: {totaloutlaysSum} " +
                        $"\nUser count: {users.Count} " +
                        $"\nAvarage summa: {avarageSumma}");

    ConsoleColor defaultColor = Console.BackgroundColor;

    Console.ForegroundColor = ConsoleColor.Yellow;
    foreach (var user in users)
    {
        var userSum = outlays.Where(ex => ex.UserLogin == user.Login).Sum(ex => ex.ProductPrice);
        var dif = avarageSumma - userSum;

        if (dif < 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"User login: {user.Login},  User sum: {userSum} Price difference: ");
            assistantFunctions.ColorTextRed(dif.ToString());

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"User login: {user.Login},  User sum: {userSum},  Price difference: ");
            assistantFunctions.ColorTextGreen(dif.ToString());
        }
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



















int CorrectReturn_Int(string text)
{
    bool isTrue = true;
    var input = 0;

    while (isTrue)
    {
        try
        {
            Console.Write($"{text}: ");
            input = int.Parse(Console.ReadLine());
            isTrue = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return input;
}




































/* 
var user = new User();

user.Name = "Test";
user.Age = 1;


user.Update("salom", 9);

Console.WriteLine(user.Name);
Console.WriteLine(user.Age);



class User
{
    public string Name;
    public int Age;

    public void Update(string name)
    {
        this.Name = name;
    }
    public void Update(string name, int age = 0)
    {
        this.Name = name;
        this.Age = age;
    }
}

*/