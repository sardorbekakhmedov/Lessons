struct Questions
{
    public string QuestionText;
    public List<string> Choice;
    public int CorrectAnswer;

    public void SaveQuestion(string questionText, List<string> choise, int corresctAnswer)
    {
        QuestionText = questionText;
        Choice = choise;
        CorrectAnswer = corresctAnswer;
    }

}