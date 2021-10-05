public static class UserAccount
{
    private static string email;
    private static string password;
    private static bool remember;

    public static string Email { get => email; set => email = value; }
    public static string Password { get => password; set => password = value; }
    public static bool Remember { get => remember; set => remember = value; }
}

public static class UserProfil
{
    public static UnityEngine.Texture texture;
    public static string role;
    public static string ign;
    public static string gender;
    public static string age;
    public static string job;
    public static string dom;
    public static string wedding_plan;
}
