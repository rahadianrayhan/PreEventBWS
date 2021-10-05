using UnityEngine;

public class DummyFill : MonoBehaviour
{
    int index = 0;
    public static DummyFill instance;
    private void Awake()
    {
        instance = this;
    }
    public void Fill()
    {
        index = 0;

        Dummy.Id[index] = 1;
        Dummy.Slot[index] = "A01";
        Dummy.Brand[index] = "Silver Booth";
        Dummy.Type[index] = 1;
        Dummy.Stand[index] = 2;
        Dummy.PropertyId[index] = 3;
        Dummy.Color[index] = "34636D";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo1.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner1.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6282316839131";
        Dummy.Information[index] = "Kami adalah Invex Store stand type silver";

        index += 1;

        Dummy.Id[index] = 2;
        Dummy.Slot[index] = "A02";
        Dummy.Brand[index] = "Gold Store";
        Dummy.Type[index] = 2;
        Dummy.Stand[index] = 1;
        Dummy.PropertyId[index] = 5;
        Dummy.Color[index] = "ff3300";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6287872002225";
        Dummy.Information[index] = "Kami adalah Invex Store stand type Gold";

        index += 1;

        Dummy.Id[index] = 3;
        Dummy.Slot[index] = "A03";
        Dummy.Brand[index] = "Platinum Store";
        Dummy.Type[index] = 3;
        Dummy.Stand[index] = 2;
        Dummy.PropertyId[index] = 9;
        Dummy.Color[index] = "66ff33";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo3.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Url_banner[index, 2] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Url_banner[index, 3] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "62816905965";
        Dummy.Information[index] = "Kami adalah Invex Store stand type Platinum";

        index += 1;

        Dummy.Id[index] = index +1;
        Dummy.Slot[index] = "A04";
        Dummy.Brand[index] = "Gold Store MUA";
        Dummy.Type[index] = 2;
        Dummy.Stand[index] = 1;
        Dummy.PropertyId[index] = 3;
        Dummy.Color[index] = "ff3300";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6282316839131";
        Dummy.Information[index] = "Sample MUA property booth stand 1";

        index += 1;

        Dummy.Id[index] = index + 1;
        Dummy.Slot[index] = "A05";
        Dummy.Brand[index] = "G-Store Attire-Jawelary";
        Dummy.Type[index] = 2;
        Dummy.Stand[index] = 2;
        Dummy.PropertyId[index] = 5;
        Dummy.Color[index] = "ff3300";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6282316839131";
        Dummy.Information[index] = "Sample Jawelery property booth stand 2";

        index += 1;

        Dummy.Id[index] = index + 1;
        Dummy.Slot[index] = "A06";
        Dummy.Brand[index] = "G-Store Catering";
        Dummy.Type[index] = 2;
        Dummy.Stand[index] = 1;
        Dummy.PropertyId[index] = 7;
        Dummy.Color[index] = "ff3300";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6282316839131";
        Dummy.Information[index] = "Sample Catering property booth stand 1";

        index += 1;

        Dummy.Id[index] = index + 1;
        Dummy.Slot[index] = "A07";
        Dummy.Brand[index] = "G-Store Venue-Dekorasi";
        Dummy.Type[index] = 2;
        Dummy.Stand[index] = 1;
        Dummy.PropertyId[index] = 9;
        Dummy.Color[index] = "ff3300";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6282316839131";
        Dummy.Information[index] = "Sample Venue dan Dekorasi property booth stand 1";

        index += 1;

        Dummy.Id[index] = index + 1;
        Dummy.Slot[index] = "A08";
        Dummy.Brand[index] = "G-Store Photo-Video";
        Dummy.Type[index] = 2;
        Dummy.Stand[index] = 2;
        Dummy.PropertyId[index] = 11;
        Dummy.Color[index] = "ff3300";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner3.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "6282316839131";
        Dummy.Information[index] = "Sample Potografer dan Videografer property booth stand 2";

        index += 1;

        Dummy.Id[index] = index+1;
        Dummy.Slot[index] = "A09";
        Dummy.Brand[index] = "Platinum Stand 1 Catering";
        Dummy.Type[index] = 3;
        Dummy.Stand[index] = 1;
        Dummy.PropertyId[index] = 8;
        Dummy.Color[index] = "66ff33";
        Dummy.Url_logo[index] = "https://mve.invex.id/storage/logo/logo2.jpg";
        Dummy.Url_banner[index, 0] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 1] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 2] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Url_banner[index, 3] = "https://mve.invex.id/storage/banner/banner2.jpg";
        Dummy.Website[index] = "https://invex.id";
        Dummy.Phone[index] = "62816905965";
        Dummy.Information[index] = "Sample booth platinum catering stand type Platinum Stand 1";
    }
}

public static class Dummy
{
    private static int[] id = new int[10];

    private static string[] slot = new string[10];
    private static string[] brand = new string[10];

    // Tipe Booth
    private static int[] type = new int[10];

    // Tipe stand
    private static int[] stand = new int[10];

    // Atribute booth download

    private static string[] color = new string[10];

    private static string[] url_video = new string[10];

    private static string[] url_logo = new string[10];

    private static string[,] url_banner = new string[10,4];

    private static int[] propertyId = new int[10];

    // attribute text
    private static string[] phone = new string[10];
    private static string[] information = new string[10];
    private static string[] website = new string[10];

    public static int[] Id { get => id; set => id = value; }
    public static string[] Slot { get => slot; set => slot = value; }
    public static int[] Type { get => type; set => type = value; }
    public static int[] Stand { get => stand; set => stand = value; }
    public static string[] Color { get => color; set => color = value; }
    public static string[] Url_logo { get => url_logo; set => url_logo = value; }
    public static string[,] Url_banner { get => url_banner; set => url_banner = value; }
    public static int[] PropertyId { get => propertyId; set => propertyId = value; }
    public static string[] Brand { get => brand; set => brand = value; }
    public static string[] Url_video { get => url_video; set => url_video = value; }
    public static string[] Website { get => website; set => website = value; }
    public static string[] Information { get => information; set => information = value; }
    public static string[] Phone { get => phone; set => phone = value; }
}