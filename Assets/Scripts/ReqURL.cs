public class ReqURL
{
    public static string base_url = "https://dev.bandungweddingseason.id/api/unity/";

    public static string booth = "booth/";
}

public class BoothID
{
    private static string slot = "";
    private static string hall = "";
    private static string tipe = "";
    private static int tipeInt = 0;
    private static string index = "";
    private static string id = "";

    public static string Slot { get => slot; set => slot = value; }
    public static string Id { get => id; set => id = value; }
    public static string Hall { get => hall; set => hall = value; }
    public static string Tipe { get => tipe; set => tipe = value; }
    public static string Index { get => index; set => index = value; }
    public static int TipeInt { get => tipeInt; set => tipeInt = value; }
}
