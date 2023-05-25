namespace iTransition_Task3;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0 || Validations.HasDuplicates(args))
        {
            Console.WriteLine("Invalid input. Please provide an odd number of unique moves.");
            Console.WriteLine("Example: rock paper scissors lizard Spock\n");
            return;
        }

        string hmacKey = Hmac.GenerateKey();
        string computerMove = Hmac.GetRandomMove(args);
        string hmac = Hmac.CalculateHMAC(computerMove, hmacKey);


        Console.WriteLine("HMAC: " + hmac);
        ViewTables.DisplayMenu(args);

        string userMove;

        do
        {
            Console.Write("Enter your move: ");
            userMove = Console.ReadLine();

            if (int.TryParse(userMove, out int moveNumber))
            {
                if (moveNumber >= 1 && moveNumber <= args.Length)
                {
                    userMove = args[moveNumber - 1];
                }
            }

        } while (!Validations.IsValidMove(userMove, args));

        Console.WriteLine("Your move: " + userMove);
        Console.WriteLine("Computer move: " + computerMove);

        int result = Validations.DetermineWinner(args.Length, Array.IndexOf(args, userMove), Array.IndexOf(args, computerMove));

        switch (result)
        {
            case 0:
                Console.WriteLine("It's a draw!");
                break;
            case > 0:
                Console.WriteLine("You win!");
                break;
            default:
                Console.WriteLine("Computer wins!");
                break;
        }

        Console.WriteLine("HMAC key: " + hmacKey);
    }

}