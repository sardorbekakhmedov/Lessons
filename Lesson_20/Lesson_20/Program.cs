

void Show() => Console.WriteLine("Show");
void Show1() => Console.WriteLine("Show11");

User._Max += Show;
User._Max -= Show1;

User.Start();

static class User
{
    public static event Max? _Max;

    public static void Start()
    {
        _Max!.Invoke();
    }
}



//delegate void Max(int x, string y);
delegate void Max();