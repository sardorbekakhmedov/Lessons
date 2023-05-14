namespace Lesson58_Identity.Entity;

public class Result
{
    public Guid Id { get; set; }
    public int Num1 { get; set; }
    public int Num2 { get; set; }
    public int Output { get; set; }
 
    public User User { get; set; }

}