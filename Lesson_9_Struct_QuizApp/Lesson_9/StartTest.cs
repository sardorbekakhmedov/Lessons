struct StartTests
{
    public void StartTest(AssistantFunction assistantFunction, int userIndex, List<Users> users, List<Questions> questions,
                                SelectionMenus selectionMenus, StartTests startTests, AddNewTests addNewTests, ShowUsers showUsers,
                                UserResults userResult, ClearResults clearResults)
    {
        Console.Clear();
        assistantFunction.ColorTextYellow($"\n\t\tWelcome  {users[userIndex].Login}");
        int correct = 0;

        ShowQuestions(assistantFunction, questions, ref correct);

        var result = new UserResults();

        result.SaveUserResult(correct, questions.Count, DateTime.Now);

        users[userIndex].Result.Add(result);
        assistantFunction.PressEnter();
        selectionMenus.Registrations(assistantFunction, selectionMenus, users,
                                     questions, startTests, addNewTests, showUsers, userResult, clearResults);
    }

    private void ShowQuestions(AssistantFunction assistantFunction, List<Questions> questions, ref int correct)
    {
        for (int i = 0; i < questions.Count; i++)
        {
            assistantFunction.ColorTextBlue($"\n{i + 1} - Question: {questions[i].QuestionText}");

            assistantFunction.ColorTextMegenta("\nOptions:");

            for (int j = 0; j < questions[i].Choice.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {questions[i].Choice[j]}");
            }

            int input = CheckOptions(assistantFunction, questions[i]);

            ChekAnswer(assistantFunction, questions[i].CorrectAnswer, input, ref correct);
        }
    }

    private int CheckOptions(AssistantFunction assistantFunction, Questions question)
    {
        bool isTrue = true;
        int answer = 0;

        do
        {
            try
            {
                assistantFunction.ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
                Console.Write("Select option index: ");
                answer = int.Parse(Console.ReadLine());

                for (int i = 0; i < question.Choice.Count; i++)
                {
                    if (answer == i + 1)
                        isTrue = false;
                }

                if (isTrue)
                    assistantFunction.ColorTextRed("\nChoose from the proposed options! ");
            }
            catch (Exception ex)
            {
                assistantFunction.ColorTextRed(ex.Message);
            }

        } while (isTrue);

        return answer;
    }

    private void ChekAnswer(AssistantFunction assistantFunction, int CorrectAnswer, int userChoise, ref int correct)
    {
        if (CorrectAnswer == userChoise - 1)
        {
            correct++;
            assistantFunction.ColorTextGreen("Correct! :) ");
        }
        else
            assistantFunction.ColorTextRed("Incorrect! :( ");

    }

}