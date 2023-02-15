using System.Collections;

var users = new List<Tuple<string, string, List<string>>>();
var questions = new List<Tuple<string, List<string>, int>>();
DefaultQuestions();

while (true)
{
    MainMenu();
    PressEnter();
}

void MainMenu()
{
    Menu.MainMenu();
    try
    {
        ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
        Console.Write("Your choise: ");
        var input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case (int)MainMenuEnum.StartTest: Registrations(); break;

            case (int)MainMenuEnum.AddQuestions: AddNewTest(); break;

            case (int)MainMenuEnum.ViewResult: AllResults(); break;

            case (int)MainMenuEnum.ListOfUsers: PrintUsers(); break;

            case (int)MainMenuEnum.Exit: Console.WriteLine(MainMenuEnum.Exit); break;

            default: UnknownCommand(); MainMenu(); break;
        }
    }
    catch (Exception ex)
    {
        ColorTextRed(ex.Message);
        PressEnter();
        MainMenu();
    }
}

void Registrations()
{
    Menu.RegisMenu();
    try
    {
        ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
        Console.Write("Your choise: ");
        var input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case (int)AccessMenuEnum.SignIn: SignIn(); break;
            case (int)AccessMenuEnum.SignUp: SignUp(); break;
            case (int)AccessMenuEnum.GoBack: MainMenu(); break;
            default: UnknownCommand(); Registrations(); break;
        }
    }
    catch (Exception ex)
    {
        ColorTextRed(ex.Message);
        PressEnter();
        Registrations();
    }
}

void AllResults()
{
    Menu.ResultMenu();
    try
    {
        ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
        Console.Write("\nYour choise: ");
        var input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case (int)ResultMenuEnum.ShowResults: ShowResults(); break;
            case (int)ResultMenuEnum.ClearAllResults: ClearMenu(); break;
            case (int)ResultMenuEnum.GoBack: MainMenu(); break;
            default: UnknownCommand(); AllResults(); break;
        }
    }
    catch (Exception ex)
    {
        ColorTextRed(ex.Message);
        PressEnter();
        AllResults();
    }
}

void ClearMenu()
{
    Menu.CleaningMenu();
    try
    {
        ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
        Console.Write("\nYour choise: ");
        var input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case (int)ClearMenuEnum.DeleteOneUsersAllResults: DeleteOneUserResult(); break;
            case (int)ClearMenuEnum.DeleteAllAllResults: ClearAllResults(); break;
            case (int)ClearMenuEnum.GoBack: MainMenu(); break;
            default: UnknownCommand(); ClearMenu(); break;
        }
    }
    catch (Exception ex)
    {
        ColorTextRed(ex.Message);
        PressEnter();
        ClearMenu();
    }
}

void AddNewTest()
{
    Console.Clear();
    ColorTextYellow("\n\t\tWelcome Add Test  SECTION! ");

    ColorTextBlue_("Enter question: ");
    var question = Console.ReadLine();

    var options = CorrectFormat("Enter the number options: ");

    List<string> list = new List<string>();

    for (int i = 0; i < options; i++)
    {
        ColorTextMegenta_($"{i + 1} enter option: ");
        list.Add(Console.ReadLine());
    }

    var correctAnswer = CorrectFormat("Enter the INDEX of the correct answer: ");

    questions.Add(new Tuple<string, List<string>, int>(question, new List<string>(list), correctAnswer - 1));

    Loading();
    ColorTextGreen("Success! ");
    PressEnter();
}

int CorrectFormat(string text)
{
    bool isTrue = true;
    var answer = 0;
    do
    {
        try
        {
            ColorTextGreen_(text);
            answer = int.Parse(Console.ReadLine());
            isTrue = false;
        }
        catch (Exception ex)
        {
            ColorTextRed(ex.Message);
        }

    } while (isTrue);

    return answer;
}

void ShowResults()
{
    Loading();
    ColorTextYellow("\n\t\tWelcome to AllResults SECTION! ");

    for (int i = 0; i < users.Count; i++)
    {
        Console.WriteLine($"User name: {users[i].Item1}");
        for (int j = 0; j < users[i].Item3.Count; j++)
        {
            Console.WriteLine(users[i].Item3[j]);
        }
    }
}

void DeleteOneUserResult()
{
    Console.Write("Enter username:");
    var username = Console.ReadLine();

    var userIndex = UserIndex(username);
    users[userIndex].Item3.Clear();
    Loading();
    ColorTextGreen($"Username: {users[userIndex].Item1} AllResults cleared! ");
}

void ClearAllResults()
{
    for (int i = 0; i < users.Count; i++)
    {
        users[i].Item3.Clear();
    }
    Loading();
    ColorTextGreen("All AllResults cleared! ");
}

int UserIndex(string login)
{
    for (int i = 0; i < users.Count; i++)
    {
        if (users[i].Item1 == login)
            return i;
    }

    ColorTextRed("No such user exists! ");

    return -1;
}

void SignIn()
{
    Console.Clear();
    ColorTextYellow(" \n\t\tWelcome to Sign IN ");

    Console.Write("\nLogin: ");
    var login = Console.ReadLine();

    Console.Write("Password: ");
    var password = Console.ReadLine();

    IfThereIsNoUser(userCount: users.Count);

    CheckHasUser(login, password);
}

void IfThereIsNoUser(int userCount)
{
    if (users.Count == 0)
    {
        ColorTextRed("\nNo such user foud! ");

        PressEnter();
        Registrations();
    }
}

void CheckHasUser(string login, string password)
{
    for (int i = 0; i < users.Count; i++)
    {
        if (users[i].Item1 == login && users[i].Item2 == password)
            StartTest(userIndex: i);
        else
            ColorTextRed("No such user exists! ");
    }
}

void SignUp()
{
    Console.WriteLine(" \n\t\tWelcome to Sign UP ");

    Console.Write("\nLogin: ");
    var login = Console.ReadLine();

    Console.Write("Password: ");
    var password = Console.ReadLine();

    users.Add(new Tuple<string, string, List<string>>(login, password, new List<string>()));

    Loading();
    ColorTextGreen("Success! ");

    PressEnter();
    Registrations();
}

void StartTest(int userIndex)
{
    Console.Clear();
    ColorTextYellow($"\n\t\tWelcome  {users[userIndex].Item1}");
    int correct = 0;

    ShowQuestions(ref correct);

    users[userIndex].Item3.Add($"{correct} / {questions.Count}");
    PressEnter();
    Registrations();
}

void ShowQuestions(ref int correct)
{
    for (int i = 0; i < questions.Count; i++)
    {
        ColorTextBlue($"\n{i + 1} - Question: {questions[i].Item1}");

        ColorTextMegenta("\nOptions:");

        for (int j = 0; j < questions[i].Item2.Count; j++)
        {
            Console.WriteLine($"{j + 1}. {questions[i].Item2[j]}");
        }

        int input = CheckOptions(questions[i]);

        ChekAnswer(questions[i].Item3, input, ref correct);
    }
}

int CheckOptions(Tuple<string, List<string>, int> question)
{
    bool isTrue = true;
    int answer = 0;

    do
    {
        try
        {
            ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
            Console.Write("Select option index: ");
            answer = int.Parse(Console.ReadLine());

            for (int i = 0; i < question.Item2.Count; i++)
            {
                if (answer == i + 1)
                    isTrue = false;
            }

            if (isTrue)
                ColorTextRed("\nChoose from the proposed options! ");
        }
        catch (Exception ex)
        {
            ColorTextRed(ex.Message);
        }

    } while (isTrue);

    return answer;
}

void ChekAnswer(int CorrectAnswer, int userChoise, ref int correct)
{
    if (CorrectAnswer == userChoise - 1)
    {
        correct++;
        ColorTextGreen("Correct! :) ");
    }
    else
        ColorTextRed("Incorrect! :( ");

}

void PrintUsers()
{
    Console.Clear();
    ColorTextYellow(" \n\t\tWelcome to Print Users \n\n");

    int countUsers = default;
    foreach (var user in users)
    {
        countUsers++;
        Console.WriteLine($"{countUsers}. User name: {user.Item1}, Password: {user.Item2}");
    }

    PressEnter();
}

void Loading()
{
    ColorTextGreen("\nLoading: ");

    Console.ForegroundColor = ConsoleColor.Yellow;
    for (int i = 0; i < 5; i++)
    {
        Console.Write("=> ");
        Thread.Sleep(400);
    }
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine();
}

void DefaultQuestions()
{
    var defaultQuestion = new Tuple<string, List<string>, int>("9 * 9 = ?", new List<string> { "72", "81", "85", "78" }, 1);
    questions.Add(defaultQuestion);
    defaultQuestion = new Tuple<string, List<string>, int>("7 * 7 = ?", new List<string> { "49", "52", "42" }, 0);
    questions.Add(defaultQuestion);
}

void UnknownCommand()
{
    ColorTextRed("\nUnknown command! ");
    PressEnter();
}

void PressEnter()
{
    ColorTextMegenta_("\nPress ENTER to continue:  ");
    Console.ReadLine();
}

void ColorTextRed(string text)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextYellow(string text)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextGreen(string text)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextGreen_(string text)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextBlue(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextBlue_(string text)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextMegenta(string text)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void ColorTextMegenta_(string text)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(text);
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}


//======================================== << ENUMS >> =============================================\\

enum MainMenuEnum
{
    StartTest = 1,
    AddQuestions,
    ViewResult,
    ListOfUsers,
    Exit
}

enum AccessMenuEnum
{
    SignIn = 1,
    SignUp,
    GoBack
}

enum ResultMenuEnum
{
    ShowResults = 1,
    ClearAllResults,
    GoBack
}

enum ClearMenuEnum
{
    DeleteOneUsersAllResults = 1,
    DeleteAllAllResults,
    GoBack
}
