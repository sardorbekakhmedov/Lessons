

var question = new Question();

question.Show();


partial class Question
{
    int Number = 45;
    public partial void Show();
}

partial class Question
{
    public partial void Show();
}


partial class Question
{
    public partial void Show()
    {
        Console.WriteLine("Question: " + Number);
    }

}

