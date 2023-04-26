using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

struct UserResults
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
        assistantFunction.ColorTextYellow("nttWelcome to AllResults SECTION!");

        for (int i = 0; i <  users.Count; i++)
        {
            Console.WriteLine($"User name: { users[i].Login}");
            for (int j = 0; j < users[i].Result.Count; j++)
            {
                Console.WriteLine($"{ j + 1}. { users[i].Result[j].GetUserResult() } ");
            }
        }
    }

}

