class ShowUsers
{
    public void PrintUsers(AssistantFunction assistantFunction, List<Users> users)
    {
        Console.Clear();
        assistantFunction.ColorTextYellow(" \n\t\tWelcome to Print Users \n\n");

        int countUsers = default;
        foreach (var user in users)
        {
            countUsers++;
            Console.WriteLine($"{countUsers}. User name: {user.Login}, Password: {user.Password} Save date: {user.DateCreated}");
        }

        assistantFunction.PressEnter();
    }

}
