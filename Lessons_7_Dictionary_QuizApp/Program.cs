Console.Clear();
Console.ForegroundColor = ConsoleColor.DarkCyan;

var test = new string[10][];
int countTest = default;
AddDefaultTest();

var addTest = new string[5];
string tempString = string.Empty;

bool toExit = true;
int countCorrect = default, countWrong = default;

var users = new string[10][];
int usersCount = 0;
var saveAttempts = new string[10][];
var attemptsCount = new int[10];

GeneralMenu();

void GeneralMenu()
{
    while (toExit)
    {
        Menu.GeneralMenu();
        Console.Write("Tanlov: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1": RegisMenu(); Console.Write("\nPress enter to continue: "); Console.ReadLine(); break;

            case "2": AddNewTest(); Console.Write("\nPress enter to continue: "); Console.ReadLine(); break;

            case "3": ResultMenu(); Console.Write("\nPress enter to continue: "); Console.ReadLine(); break;

            case "4": ShowUsers(users); Console.Write("\nPress enter to continue: "); Console.ReadLine(); break;

            case "5": toExit = false; break;

            default: Console.WriteLine("No malum buyruq berildi ! \nMenudan qayta tanlang: "); break;
        }
    }
}

void PrintResult()
{
    Console.Clear();
    Console.Write("Loading: ");
    for (int i = 0; i < 5; i++)
    {
        Console.Write("=>  ");
        Thread.Sleep(500);
    }
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Test results: \n");
    Console.ForegroundColor = ConsoleColor.DarkCyan;

    for (int i = 0; i < users.Length; i++)
    {
        if (users[i] == null)
            break;

        Console.WriteLine($"User name: {users[i][0]}");

        if (saveAttempts[i][0] is null)
        {
            Console.WriteLine("Urishlar soni 0");
            break; ;
        }

        for (int j = 0; j < saveAttempts[i].Length; j++)
        {
            if (saveAttempts[i][j] is null)
                break;

            Console.WriteLine($"{j + 1}. {saveAttempts[i][j]}");
        }
    }
}

void ResultMenu()
{
    Menu.ResultMenu();
b:
    Console.Write("\nTanlov: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1": PrintResult(); break;

        case "2": ClearResult(); break;

        case "3": GeneralMenu(); break;

        default: Console.WriteLine("Bunday buyruq yo'q!"); goto b;
    }
}

void ClearResult()
{
    saveAttempts = new string[10][];
    Console.WriteLine("All results cleared! ");
}

void AddNewTest()
{
    if (countTest == 10)
    {
        Console.WriteLine("Test soni 10 ta ga yetdi");
        return;
    }

    test[countTest++] = GetNewQuestions(addTest, tempString);
}

string[] GetNewQuestions(string[] addTest, string tempString)
{
    for (int i = default; i < addTest.Length; i++)
    {
        switch (i)
        {
            case 0: tempString = "Savolni kiriting: "; break;
            case 1: tempString = "Variantni_1: "; break;
            case 2: tempString = "Variantni_2: "; break;
            case 3: tempString = "Variantni_3: "; break;
            case 4: tempString = "To'g'ri javob :=  "; break;
        }
        Console.Write(tempString);
        addTest[i] = Console.ReadLine();
    }
    return addTest;
}

void RegisMenu()
{
    Menu.RegisMenu();
b:
    Console.Write("Tanlov: ");
    var tanlov = Console.ReadLine();

    switch (tanlov)
    {
        case "1": SignIn(); break;

        case "2": SignUp(); break;

        case "3": GeneralMenu(); break;

        default: Console.WriteLine("Bunday buyruq yo'q!"); goto b;
    }
}

void SignIn()
{
    Console.WriteLine("Welcome to Sign In: ");

    Console.Write("\nUser loginini kiriting: ");
    var log = Console.ReadLine();
    Console.Write("Parolni kiriting: ");
    var par = Console.ReadLine();

    if (users[0] is null)
    {
        Console.WriteLine($"\nSiz Userlar ro'yxatida yo'qsiz! \nIltimos oldin ro'yxatdan o'ting!");

        Console.Write("\nPress enter to continue: "); Console.ReadLine();

        RegisMenu();
        return;
    }

    CheckHasUsers(login: log, password: par);
}

void CheckHasUsers(string login, string password)
{
    for (int i = 0; i < users.Length; i++)
    {
        if (users[i] is null)
        {
            break;
        }

        if (users[i][0] == login && users[i][1] == password)
        {
            Console.Clear();
            Console.WriteLine("Welcome: " + login);
            StartTest(userIndex: i);
            break;
        }
        else if (i == users.Length - 1)
        {
            Console.WriteLine("\nSiz Userlar ro'yxatida yo'qsiz! " +
                                "\nIltimos oldin ro'yxatdan o'ting!");
            ResultMenu();
            break; ;
        }
    }
}

void SignUp()
{
    Console.WriteLine("\nWelcome to Sign Up: \n");

    Console.Write("New Users Login: ");
    var log = Console.ReadLine();
    Console.Write("New Users Password: ");
    var par = Console.ReadLine();

    users[usersCount] = new string[] { log, par };
    saveAttempts[usersCount++] = new string[10];

    Console.Clear();
    Console.WriteLine("Welcome new user: " + log);

    RegisMenu();
    return;
}

void StartTest(int userIndex)
{
    if (attemptsCount[userIndex] == 10)
    {
        Console.WriteLine("Sizda boshqa urinish qolmadi!. ");
        return;
    }

    countCorrect = 0;

    ShowOptionsTest();

    SaveResults(userIndex, countCorrect);

    return;
}

void ShowOptionsTest()
{
    for (int i = 0; i < test.Length; i++)
    {
        if (test[i] == null)
            break;

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"\nQuestion => {i + 1} : ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        for (int j = 0; j < test[i].Length - 1; j++)
        {
            Console.WriteLine(test[i][j]);
        }

        var answer = CheckOptions(index: i);

        CheckAnswer(answer, index: i);
    }
}

void CheckAnswer(string answer, int index)
{
    if (answer == test[index][test[index].Length - 1])
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("The answer is correct :)");
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        // tempString += $"\nQuestion => {(i + 1)} : {test[i][0]} \nAnswer: {answer} \nThe answer is correct :) \n";
        countCorrect++;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("The answer is wrong :( ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        // tempString += $"\nQuestion => {(i + 1)} : {test[i][0]} \nAnswer: {answer} \nThe answer is wrong :( \n";
        countWrong++;
    }
}

void SaveResults(int userIndex, int correctCount)
{
    var urinSoni = attemptsCount[userIndex];
    saveAttempts[userIndex][urinSoni] = $"{countCorrect} / {countTest}";

    urinSoni++;
    attemptsCount[userIndex] = urinSoni;


    // results[k++] = $"{k}. {countCorrect} / {countTest} ";

    /* results[k++] = $"User Name: {name} " +
                     $"\n{k} - Urunish:  " +
                     $"\nTo'g'ri javoblar soni: {countCorrect} " +
                     $"\nNo to'g'ri javoblar soni: {countWrong} " +
                     $"\nSavollar soni: {countTest} " +
                     $"\n{tempString}";*/
}

string CheckOptions(int index)
{
    string answer;
    bool isTrue = true;

    do
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Write("Answer: ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        answer = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        if (answer == test[index][1] || answer == test[index][2] || answer == test[index][3])
        {
            isTrue = false;
        }
        else
        {
            Console.WriteLine("Please use only the options provided !");
            isTrue = true;
        }

    } while (isTrue);

    return answer;
}

void AddDefaultTest()
{
    test[countTest++] = new string[] { "9 * 8 = ?", "73", "68", "72", "72" };
    test[countTest++] = new string[] { "9 * 9 = ?", "81", "91", "96", "81" };
}

void ShowUsers(string[][] users)
{
    if (users[0] is null)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nNo users yet!");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        return;
    }

    Console.WriteLine("\nList of users ");


    for (int i = 0; i < users.Length; i++)
    {
        if (users[i] is null)
        {
            break;
        }
        Console.WriteLine($"{i + 1}. {users[i][0]}");
    }
}


// ===================  <<  Dictionary  >> ===========================//


/*
Dictionary<char, char> uzRu = new Dictionary<char, char>()
{
    { 'a',  'а'},
    { 'b',  'б'},
    { 'c',  'c'},
    { 'd',  'д'},
    { 'e',  'э'},
    { 'f',  'ф'},
    { 'g',  'г'},
    { 'h',  'ҳ'},
    { 'i',  'и'},
    { 'j',  'ж'},
    { 'k',  'к'},
    { 'l',  'л'},
    { 'm',  'м'},
    { 'n',  'н'},
    { 'o',  'о'},
    { 'p',  'п'},
    { 'q',  'қ'},
    { 'r',  'р'},
    { 's',  'с'},
    { 't',  'т'},
    { 'u',  'у'},
    { 'v',  'в'},
    { 'w',  'в'},
    { 'x',  'x'},
    { 'y',  'й'},
    { 'z',  'з'},
    { '.',  '.'},
    { ',',  ','},
    { ' ',  ' '},
    { '\'',  '\''}
};

Console.Write("Enter text: ");
string str = default;

while (true)
{
    try
    {
        var input = Console.ReadKey().KeyChar;
        Console.Clear();

        if (input == 8)
        {
            str = str.Substring(0, str.Length - 1);
            Console.Write(str);
        }
        else
        {
            str += uzRu[input];
            Console.Write(str);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

*/