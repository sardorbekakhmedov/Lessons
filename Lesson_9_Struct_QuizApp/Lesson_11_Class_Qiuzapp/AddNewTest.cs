struct AddNewTests
{
    public void AddNewTest(AssistantFunction assistantFunction, List<Questions> questions)
    {
        Console.Clear();
        assistantFunction.ColorTextYellow("\n\t\tWelcome Add Test  SECTION! ");

        assistantFunction.ColorTextBlue_("Enter question: ");
        var question = Console.ReadLine();

        var options = CorrectFormat(assistantFunction, "Enter the number options: ");

        List<string> list = new List<string>();

        for (int i = 0; i < options; i++)
        {
            assistantFunction.ColorTextMegenta_($"{i + 1} enter option: ");
            list.Add(Console.ReadLine());
        }

        var correctAnswer = CorrectFormat(assistantFunction, "Enter the INDEX of the correct answer: ");

        var newQuestion = new Questions();
        newQuestion.SaveQuestion(question, list, correctAnswer - 1);

        questions.Add(newQuestion);

        assistantFunction.Loading();
        assistantFunction.ColorTextGreen("Success! ");
        assistantFunction.PressEnter();
    }

    private int CorrectFormat(AssistantFunction assistantFunction, string text)
    {
        bool isTrue = true;
        var answer = 0;
        do
        {
            try
            {
                assistantFunction.ColorTextGreen_(text);
                answer = int.Parse(Console.ReadLine());
                isTrue = false;
            }
            catch (Exception ex)
            {
                assistantFunction.ColorTextRed(ex.Message);
            }

        } while (isTrue);

        return answer;
    }
}

