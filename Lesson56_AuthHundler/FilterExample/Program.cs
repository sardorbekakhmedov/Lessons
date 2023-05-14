using System.Reflection;

bool hasFilter = typeof(UserController)
    .GetMethod("Profile")
    .GetCustomAttributes()
    .Any(a => a.GetType() == typeof(FilterAttribute));

if (hasFilter)
{
    var filterIsValid = new FilterAttribute().IsValid();

    if (filterIsValid)
        return;
}

var user = new UserController().Profile();


public class UserController
{
    [Filter]
    public string Profile()
    {
        return "Ali";
    }
}

public  class FilterAttribute : Attribute
{
    public bool IsValid()
    {
        return true;
    }
}
