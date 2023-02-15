
static class Menu
{
    public static void MainMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n============== << MAIN MENU >> ================");
        Console.WriteLine("||                                           ||");
        Console.WriteLine("||            1. Start test                  ||");
        Console.WriteLine("||            2. Add questions               ||");
        Console.WriteLine("||            3. View results                ||");
        Console.WriteLine("||            4. List of users               ||");
        Console.WriteLine("||                                           ||");
        Console.WriteLine("||            CTRL + C. EXIT                 ||");
        Console.WriteLine("||                                           ||");
        Console.WriteLine("===============================================\n");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public static void RegisMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n========== << ACCESS MENU >> ===========");
        Console.WriteLine("||                                    ||");
        Console.WriteLine("||           1. Sign In               ||");
        Console.WriteLine("||           2. Sign Up               ||");
        Console.WriteLine("||           3. Go back               ||");
        Console.WriteLine("||                                    ||");
        Console.WriteLine("========================================\n");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public static void ResultMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n======== << RESULTS MENU >> ==============");
        Console.WriteLine("||                                     ||");
        Console.WriteLine("||         1. Show result              ||");
        Console.WriteLine("||         2. Clear results            ||");
        Console.WriteLine("||         3. Go back                  ||");
        Console.WriteLine("||                                     ||");
        Console.WriteLine("==========================================\n");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public static void CleaningMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n======= << CLEANING MENU >> ===============");
        Console.WriteLine("||                                      ||");
        Console.WriteLine("||      1. Delete one user's results    ||");
        Console.WriteLine("||      2. Delete all results           ||");
        Console.WriteLine("||      3. Go back                      ||");
        Console.WriteLine("||                                      ||");
        Console.WriteLine("==========================================\n");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }
}


