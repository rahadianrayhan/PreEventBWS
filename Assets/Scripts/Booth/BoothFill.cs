using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoothGenerator))]
public class BoothFill: MonoBehaviour
{
    public static BoothFill instances;

    private string brand;
    private string companyName;
    private string videoUrl;
    private string slot;
    private int id;
    private int type;
    private int stand;
    private string color;
    private int propertyId;
    private bool isCatering;

    private string url_website;
    private string phone_number;
    private string information;

    public Texture textureLogo;
    public List<Texture> textureBanner;

    public BoothProps props;
    private BoothGenerator generator;

    public GameObject currentStand;
    public GameObject currentProperty;

    public Placement place;

    public BoothProps Props { get => props; set => props = value; }
    public string Brand { get => brand; set => brand = value; }
    public string VideoUrl { get => videoUrl; set => videoUrl = value; }
    public Texture TextureLogo { get => textureLogo; set => textureLogo = value; }
    public int Id { get => id; set => id = value; }
    public string Slot { get => slot; set => slot = value; }
    public string Url_website { get => url_website; set => url_website = value; }
    public string Phone_number { get => phone_number; set => phone_number = value; }
    public string Information { get => information; set => information = value; }
    public bool IsCatering { get => isCatering; set => isCatering = value; }
    public string CompanyName { get => companyName; set => companyName = value; }

    private void Awake()
    {
        ClearBooth();
        generator = GetComponent<BoothGenerator>();
        instances = this;
    }

    public void ClearBooth()
    {
        textureBanner.Clear();
        textureLogo = null;
        brand = "";
        videoUrl = "";
        id = 0;
        slot = "";
        type = 0;
        stand = 0;
        color = "";
        propertyId = 0;
        information = "";
        phone_number = "";
        url_website = "";
        isCatering = false;
        Destroy(currentStand);
        Destroy(currentProperty);
    }

    public void SetupBooth(int _type, int _stand, int _propsId, string _color)
    {
        type = _type;
        stand = _stand;
        propertyId = _propsId;
        color = _color;

        if(_propsId >=7 && _propsId <= 8)
        {
            isCatering = true;
        }
        else
        {
            isCatering = false;
        }

        Transform parrent = null;
        switch (type)
        {
            case 3:
                parrent = place.silver;
                break;
            case 2:
                parrent = place.gold;
                break;
            case 1:
                parrent = place.platinum;
                break;
            default:
                parrent = place.platinum;
                break;
        }

        GameObject b = Instantiate(generator.GetBooth(type, stand), parrent.transform);
        b.transform.SetParent(parrent.transform);
        b.name = "Booth";
        Props = b.GetComponent<BoothProps>();

        GameObject p = Instantiate(generator.GetProperty(type, propertyId), parrent.transform);
        p.transform.SetParent(parrent.transform);
        p.name = "property";

        currentStand = b;
        currentProperty = p;
    }

    public void AddBannerTexture(Texture _texture)
    {
        textureBanner.Add(_texture);
    }

    public void SetUpProps()
    {
        props.tx_brand.text = brand;
        //props.tv_video.SetUrl(videoUrl);
        props.SetLogo(textureLogo);
        props.SetBanner();

        props.ContentVideo(videoUrl);
        props.ContentInfo(information, url_website);
    }
}

[System.Serializable]
public class Placement
{
    public Transform silver;
    public Transform gold;
    public Transform platinum;
}