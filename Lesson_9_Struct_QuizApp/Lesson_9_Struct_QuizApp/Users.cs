struct Users
{
    private string login;
    private string password;
    public List<UserResults> Result;

    public string Login
    {
        get { return login; }
        set
        {
            if (value.Length >= 3 && value.Length <= 8)
            {
                login = value;
            }
            else
            {
                Console.WriteLine("Invalid name");
            }
        }
    }

    public string Password
    {
        get { return password; }
        set
        {
            if (value.Length >= 3 && value.Length <= 8)
            {
                password = value;
            }
            else
            {
                Console.WriteLine("Invalid password");
            }
        }
    }

    public bool CheckLoginAndPassword(string login, string password)
    {
        if (this.login == login && this.password == password)
        {
            return true;
        }

        return false;
    }

    public void SaveUser(string login, string password)
    {
        this.login = login;
        this.password = password;
        Result = new List<UserResults>();
    }


}
