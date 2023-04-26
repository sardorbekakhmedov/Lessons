static class OutlayAppMenu
{
    public static string RegistrationMenu(User user)
    {
        user.NextMessage = ENextMessage.Menu;
        return $"Xarajat Botga xush kelibsiz!\n" +
                 $"\n   << Registration Menu >>  \n" +
                 $"\n1. Signup" +
                 $"\n2. Signin";
    }              

    public static string GetOutlayMenu()
    {
        return $"\n   << Outlay Menu >>  \n" +
                $"\n1. Add Autlay " +
                $"\n2. Conculate " +
                $"\n3. Show Autlays " +
                $"\n4. Registration  ";
    }
}
