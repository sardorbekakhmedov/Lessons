class ClearResults
{
    public void DeleteOneUserResult(AssistantFunction assistantFunction, List<Users> users)
    {
        Console.Write("Enter username:");
        var username = Console.ReadLine();

        var userIndex = UserIndex(assistantFunction, users, username);
        users[userIndex].Result.Clear();
        assistantFunction.Loading();
        assistantFunction.ColorTextGreen($"Username: {users[userIndex].Login} AllResults cleared! ");
    }

    public void ClearAllResults(AssistantFunction assistantFunction, List<Users> users)
    {
        for (int i = 0; i < users.Count; i++)
        {
            users[i].Result.Clear();
        }
        assistantFunction.Loading();
        assistantFunction.ColorTextGreen("All AllResults cleared! ");
    }

    public int UserIndex(AssistantFunction assistantFunction, List<Users> users, string login)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Login == login)
                return i;
        }

        assistantFunction.ColorTextRed("No such user exists! ");

        return -1;
    }

}