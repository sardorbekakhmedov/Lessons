using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

class UserResults
{
    public int CorrectAnswerCount;
    public int QuestionsCount;
    public DateTime Date;

    public void SaveUserResult(int correctCount, int questionsCount, DateTime date)
    {
        CorrectAnswerCount = correctCount;
        QuestionsCount = questionsCount;
        Date = date;
    }
     
    public string GetUserResult()
    {
        return $"{CorrectAnswerCount} / { QuestionsCount},  SaveDate:  { Date}";
    }


    public void ShowResults(AssistantFunction assistantFunction, List<Users> users)
    {
        assistantFunction.Loading();
        assistantFunction.ColorTextYellow("\n\t\tWelcome to AllResults SECTION!");

        for (int i = 0; i <  users.Count; i++)
        {
            Console.WriteLine($"User name: { users[i].Login}");
            for (int j = 0; j < users[i].Result.Count; j++)
            {
                Console.WriteLine($"{ j + 1}. { users[i].Result[j].GetUserResult() } ");
            }
        }

        UserWithTheMostCorrectAnswers(assistantFunction, users);
    }

    public void UserWithTheMostCorrectAnswers (AssistantFunction assistantFunction, List<Users> users)
    {
        // assistantFunction.Loading();
         assistantFunction.ColorTextYellow("\t\t\nUser With The Most Correct Answers!\n"); 

        // var maxResultCount = users.Max(user => user.Result.Count);
        // var maxUserLogin = users.Where(user => user.Result.Count == maxResultCount).Select(user => user.Login);

        int maxCorrectCount = default;

        string? maxUserLogin = default;

        foreach (var user in users)
        {          
            for (int i = 0; i < user.Result.Count; i++)
            {
                if (user.Result[i].CorrectAnswerCount >= maxCorrectCount)
                {
                    maxCorrectCount = user.Result[i].CorrectAnswerCount;
                    maxUserLogin = user.Login;
                }
            }
        }
         
        Console.WriteLine($"\nUser: {maxUserLogin},  Max result: {maxCorrectCount}");
    }
}

