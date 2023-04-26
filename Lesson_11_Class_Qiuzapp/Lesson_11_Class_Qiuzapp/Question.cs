class Questions
{
    public string QuestionText;
    public List<string> Choice;
    public int CorrectAnswer;
    public string UserName;
    public DateTime Date;

    public void SaveQuestion(string questionText, List<string> choise, int corresctAnswer, string userName)
    {
        QuestionText = questionText;
        Choice = choise;
        CorrectAnswer = corresctAnswer;
        UserName = userName;
        Date = DateTime.Now;
    }


    public string GetQuestionsValues( Questions question)
    {
        return $"\nAuthor name: {question.UserName} " +
                $"\nQuestionText: {question.QuestionText},  Choises: {GetChoises(question.Choice)} Date time: {question.Date}.";
    }

    public string GetChoises (List<string> choises)
    {
        string temp = "";

        foreach (var item in choises)
        {
            temp += $"{item},  ";
        }
        return temp;
    }
}