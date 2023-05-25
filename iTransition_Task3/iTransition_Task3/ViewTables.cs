namespace iTransition_Task3;

public class ViewTables
{
    public static void DisplayMenu(string[] moves)
    {
        Console.WriteLine("Available moves:");
        for (int i = 0; i < moves.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {moves[i]}");
        }

        Console.WriteLine("\n0 - exit");
        Console.WriteLine("? - help");
    }

    public static void DisplayHelpTable(string[] moves)
    {
        int n = moves.Length;
        string[,] table = new string[n + 1, n + 1];

        // Set headers
        table[0, 0] = "Move";
        for (int i = 0; i < n; i++)
        {
            table[0, i + 1] = moves[i];
            table[i + 1, 0] = moves[i];
        }

        // Fill the table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                int result = Validations.DetermineWinner(n, i - 1, j - 1);
                if (result == 0)
                {
                    table[i, j] = "Draw";
                }
                else if (result > 0)
                {
                    table[i, j] = "Win";
                }
                else
                {
                    table[i, j] = "Lose";
                }
            }
        }

        // Display the table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                Console.Write($"{table[i, j],-6}");
            }
            Console.WriteLine();
        }
    }
}