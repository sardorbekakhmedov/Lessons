struct DefaultQuestions
{
    public void DefaultQuestion(List<Questions> questions)
    {
        var defaultQuestion1 = new Questions();
        defaultQuestion1.SaveQuestion("9 * 9 = ?", new List<string> { "72", "81", "85", "78" }, 1);

        questions.Add(defaultQuestion1);

        var defaultQuestion2 = new Questions();
        defaultQuestion2.SaveQuestion("7 * 7 = ?", new List<string> { "49", "52", "42" }, 0);

        questions.Add(defaultQuestion2);
    }

}