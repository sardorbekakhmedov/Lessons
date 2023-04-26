struct SelectionMenus
{
    public void MainMenu(AssistantFunction assistantFunction, SelectionMenus selectionMenus,
                            List<Users> users, List<Questions> questions, StartTests startTests,
                            AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults)
    {
        Menu.MainMenu();
        try
        {
            assistantFunction.ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
            Console.Write("Your choise: ");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case (int)Enums.MainMenuEnum.StartTest:
                    selectionMenus.Registrations(assistantFunction, selectionMenus, users,
                                                    questions, startTests, addNewTests, showUsers, userResult, clearResults); break;

                case (int)Enums.MainMenuEnum.AddQuestions: addNewTests.AddNewTest(assistantFunction, questions); break;

                case (int)Enums.MainMenuEnum.ViewResult:
                    AllResults(assistantFunction, selectionMenus, users, questions,
                                                                    startTests, addNewTests, showUsers, userResult, clearResults); break;

                case (int)Enums.MainMenuEnum.ListOfUsers: showUsers.PrintUsers(assistantFunction, users); break;

                case (int)Enums.MainMenuEnum.Exit: Console.WriteLine(Enums.MainMenuEnum.Exit); break;

                default:
                    assistantFunction.UnknownCommand(); selectionMenus.MainMenu(assistantFunction, selectionMenus, users,
                                                                questions, startTests, addNewTests, showUsers, userResult, clearResults); break;
            }
        }
        catch (Exception ex)
        {
            assistantFunction.ColorTextRed(ex.Message);
            assistantFunction.PressEnter();
            selectionMenus.MainMenu(assistantFunction, selectionMenus, users,
                                   questions, startTests, addNewTests, showUsers, userResult, clearResults);
        }
    }

    void AllResults(AssistantFunction assistantFunction, SelectionMenus selectionMenus,
                            List<Users> users, List<Questions> questions, StartTests startTests,
                            AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults)
    {
        Menu.ResultMenu();
        try
        {
            assistantFunction.ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
            Console.Write("\nYour choise: ");
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case (int)Enums.ResultMenuEnum.ShowResults: userResult.ShowResults(assistantFunction, users); break;

                case (int)Enums.ResultMenuEnum.ClearAllResults:
                    ClearMenu(assistantFunction, selectionMenus, users, questions, startTests,
                                                              addNewTests, showUsers, userResult, clearResults); break; ; break;

                case (int)Enums.ResultMenuEnum.GoBack:
                    selectionMenus.MainMenu(assistantFunction, selectionMenus, users, questions,
                                   startTests, addNewTests, showUsers, userResult, clearResults); break;

                default:
                    assistantFunction.UnknownCommand(); AllResults(assistantFunction, selectionMenus, users, questions,
                                                                    startTests, addNewTests, showUsers, userResult, clearResults); break;
            }
        }
        catch (Exception ex)
        {
            assistantFunction.ColorTextRed(ex.Message);
            assistantFunction.PressEnter();
            AllResults(assistantFunction, selectionMenus, users, questions, startTests,
                                 addNewTests, showUsers, userResult, clearResults);
        }
    }


    void ClearMenu(AssistantFunction assistantFunction, SelectionMenus selectionMenus,
                            List<Users> users, List<Questions> questions, StartTests startTests,
                            AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults)
    {
        Menu.CleaningMenu();
        try
        {
            assistantFunction.ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
            Console.Write("\nYour choise: ");
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case (int)Enums.ClearMenuEnum.DeleteOneUsersAllResults: clearResults.DeleteOneUserResult(assistantFunction, users); break;

                case (int)Enums.ClearMenuEnum.DeleteAllAllResults: clearResults.ClearAllResults(assistantFunction, users); break;

                case (int)Enums.ClearMenuEnum.GoBack:
                    selectionMenus.MainMenu(assistantFunction, selectionMenus, users, questions,
                                                                startTests, addNewTests, showUsers, userResult, clearResults); break;

                default:
                    assistantFunction.UnknownCommand(); ClearMenu(assistantFunction, selectionMenus, users, questions, startTests,
                                                              addNewTests, showUsers, userResult, clearResults); break;
            }
        }
        catch (Exception ex)
        {
            assistantFunction.ColorTextRed(ex.Message);
            assistantFunction.PressEnter();
            ClearMenu(assistantFunction, selectionMenus, users, questions, startTests,
                                                             addNewTests, showUsers, userResult, clearResults);
        }
    }


    public void Registrations(AssistantFunction assistantFunction, SelectionMenus selectionMenus, List<Users> users, List<Questions> questions,
                               StartTests startTests, AddNewTests addNewTests, ShowUsers showUsers, UserResults userResult, ClearResults clearResults)
    {
        var signInAndSignUp = new SignInAndSignUp();

        Menu.RegisMenu();
        try
        {
            assistantFunction.ColorTextMegenta("\nIndexes example [ 1, 2, 3 ... ] ");
            Console.Write("Your choise: ");
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case (int)Enums.AccessMenuEnum.SignIn:
                    signInAndSignUp.SignIn(assistantFunction, selectionMenus, users, questions, startTests,
                                            addNewTests, showUsers, userResult, clearResults); break;

                case (int)Enums.AccessMenuEnum.SignUp:
                    signInAndSignUp.SignUp(assistantFunction, selectionMenus, users, questions, startTests,
                                                    addNewTests, showUsers, userResult, clearResults); break;

                case (int)Enums.AccessMenuEnum.GoBack:
                    selectionMenus.MainMenu(assistantFunction, selectionMenus, users,
                                                                questions, startTests, addNewTests, showUsers, userResult, clearResults); break;

                default:
                    assistantFunction.UnknownCommand(); selectionMenus.Registrations(assistantFunction, selectionMenus, users,
                                                                 questions, startTests, addNewTests, showUsers, userResult, clearResults); break;
            }
        }
        catch (Exception ex)
        {
            assistantFunction.ColorTextRed(ex.Message);
            assistantFunction.PressEnter();
            selectionMenus.Registrations(assistantFunction, selectionMenus, users,
                                       questions, startTests, addNewTests, showUsers, userResult, clearResults);
        }
    }


}
