class SignInAndSignUp
{
    public void SignUp(AssistantFunction assistantFunction, SelectionMenus selectionMenus, List<Users> users, List<Questions> questions,
                               StartTests startTests, AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults)
    {
        Console.WriteLine(" \n\t\tWelcome to Sign UP ");

        Console.Write("\nLogin: ");
        var login = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        var newUser = new Users();

        newUser.SaveUser(login, password);

        users.Add(newUser);

        assistantFunction.Loading();
        assistantFunction.ColorTextGreen("Success! ");

        assistantFunction.PressEnter();
        selectionMenus.Registrations(assistantFunction, selectionMenus, users,
                                  questions, startTests, addNewTests, showUsers, userResult, clearResults, login);
    }



    public void SignIn(AssistantFunction assistantFunction, SelectionMenus selectionMenus,
                        List<Users> users, List<Questions> questions, StartTests startTests,
                        AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults)
    {
        Console.Clear();
        assistantFunction.ColorTextYellow(" \n\t\tWelcome to Sign IN ");

        Console.Write("\nLogin: ");
        var login = Console.ReadLine();

        Console.Write("Password: ");
        var password = Console.ReadLine();

        IfThereIsNoUser(users.Count, assistantFunction, selectionMenus, users, questions, startTests,
                        addNewTests, showUsers, userResult, clearResults, login!);

        CheckHasUser(assistantFunction, questions, users, startTests, selectionMenus, login!, password!, addNewTests, showUsers, userResult, clearResults, login);
    }


    private void IfThereIsNoUser(int userCount, AssistantFunction assistantFunction, SelectionMenus selectionMenus, List<Users> users, 
                            List<Questions> questions, StartTests startTests, AddNewTests addNewTests, ShowUsers showUsers, 
                            UserResults userResult, ClearResults clearResults, string userName)
    {
        if (userCount == 0)
        {
            assistantFunction.ColorTextRed("\nNo such user foud! ");

            assistantFunction.PressEnter();
            selectionMenus.Registrations(assistantFunction, selectionMenus, users,
                                  questions, startTests, addNewTests, showUsers, userResult, clearResults, userName);
        }
    }


    private void CheckHasUser(AssistantFunction assistantFunction, List<Questions> questions, List<Users> users,
                               StartTests startTests, SelectionMenus selectionMenus, string login, string password,
                               AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults, string userName)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].CheckLoginAndPassword(login, password))
                startTests.StartTest(assistantFunction, userIndex: i, users, questions, selectionMenus, startTests,
                                        addNewTests, showUsers, userResult, clearResults, userName);
            else
                assistantFunction.ColorTextRed("No such user exists! ");
        }
    }

}
