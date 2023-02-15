struct User
{
    public string Login;

    public string Password;

    public void SaveNewUser (string login, string password)
    {
        Login = login; 
        Password = password;
    }
}