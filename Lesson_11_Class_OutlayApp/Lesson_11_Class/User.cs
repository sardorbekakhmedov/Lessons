class User
{
    public string Login;
    public string Password;



    public bool CheckLogin(List<User> users, string login)
    {
        return users.Any(user => user.Login == login);
    }

    public void SaveNewUser (string login, string password)
    {
        Login = login;
        Password = password;
    }
}

