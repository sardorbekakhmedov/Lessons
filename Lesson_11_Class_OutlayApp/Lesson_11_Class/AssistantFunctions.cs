class AssistantFunctions
{
    public int CorrectReturn_Int(string text)
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

    public void Loading(string successText)
    {
        ColorTextGreen("\nLoading: ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < 5; i++)
        {
            Console.Write("=> ");
            Thread.Sleep(400);
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{successText.ToUpper()} !");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void UnknownCommand()
    {
        ColorTextRed("\nUnknown command! ");
        PressEnter();
    }

    public void PressEnter()
    {
        ColorTextMegenta_("\nPress ENTER to continue:  ");
        Console.ReadLine();
    }

    public void ColorTextRed(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextYellow(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextGreen(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextGreen_(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextBlue(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextBlue_(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextMegenta(string text)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }

    public void ColorTextMegenta_(string text)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
    }


}
