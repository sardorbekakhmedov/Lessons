
var users = new List<Users>();
var questions = new List<Questions>();

var assistantFunction = new AssistantFunction();
var userResult = new UserResults();
var startTests = new StartTests();
var addNewTest = new AddNewTests();
var selectionMenus = new SelectionMenus();
var showUsers = new ShowUsers();
var clearResults = new ClearResults();
var defaultQuestions = new DefaultQuestions();


defaultQuestions.DefaultQuestion(questions);

string userName = "";

while (true)
{
    selectionMenus.MainMenu(assistantFunction, selectionMenus, users, questions, startTests,
                                            addNewTest, showUsers, userResult, clearResults, userName);
    assistantFunction.PressEnter();
}


