namespace iTransition_Task3;

public class Validations
{

    public static bool HasDuplicates(string[] moves)
    {
        var set = new HashSet<string>();

        foreach (string move in moves)
        {
            if (!set.Add(move))
            {
                return true;
            }
        }
        return false;
    }


    public static bool IsValidMove(string move, string[] moves)
    {
        if (move == "?" || move == "0")
        {
            ViewTables.DisplayHelpTable(moves);
            return false;
        }

        if (Array.IndexOf(moves, move) != -1)
        {
            return true;
        }

        Console.WriteLine("Invalid move. Please choose a valid move from the menu.");
        return false;
    }


    public static int DetermineWinner(int totalMoves, int userMove, int computerMove)
    {
        // Calculate the winning range
        int halfMoves = totalMoves / 2;
        int start = (userMove + halfMoves) % totalMoves;
        int end = (userMove - halfMoves + totalMoves) % totalMoves;

        if (start == end)
        {
            return 0; // Draw
        }
        else if (start < end)
        {
            return (computerMove > start && computerMove <= end) ? 1 : -1;
        }
        else
        {
            return (computerMove > start || computerMove <= end) ? 1 : -1;
        }
    }


}