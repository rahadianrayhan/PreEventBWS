using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoothGenerator : MonoBehaviour
{
    public Stand stand;
    public Property property;
    private int index;

    public GhostBooth gb;
    public DemoGold demo;

    private GameObject currentBooth;

    [SerializeField] private BoothFill boothfill;

    private void Start()
    {
        LoadBoothDemo();
    }

    public void Generate(string _slot)
    {
        //ZP1
        BoothID.Slot = _slot;
        BoothID.Hall = _slot.Substring(0, 1);

        string charType = _slot.Substring(1, 1);
        BoothID.Tipe = charType;

        switch (charType)
        {
            case "P":
                BoothID.TipeInt = 1;
                break;
            case "G":
                BoothID.TipeInt = 2;
                break;
            case "S":
                BoothID.TipeInt = 3;
                break;
        }

        BoothID.Index = _slot.Substring(2, _slot.Length - 2);

        //Debug.Log(BoothID.Slot + " " + BoothID.Hall + " " + BoothID.Tipe + " " + BoothID.Index + " ");
        if(_slot != "ZG1")
        {
            LoadBooth.LoadAPI();
        }
        else
        {
            LoadBoothDemo();
        }
        
    }

    private void LoadBoothDemo()
    {
        int type = 2;
        int stand = 1;
        int props = 11;
        string color = "";

        boothfill.ClearBooth();

        boothfill.Id = 999;
        boothfill.Brand = "Rely Studio";
        boothfill.CompanyName = "Relly Studio";
        

        boothfill.SetupBooth(type, stand, props, color);

        boothfill.Information = "<b>Rely Studio</b>\n\n" +
            "Love Story Photo & Videography\n" +
            "Live Stream\n\n" +
            "Graduation inquiries @rely.graduation\n" +
            "WA : 081122336633\n" +
            "Bandung\n";

        boothfill.Phone_number = "6281122336633";
        boothfill.Url_website = "https://www.instagram.com/rely.studio/";
        string pathFile = System.IO.Path.Combine(Application.streamingAssetsPath, "wedd.mp4"); ;
        boothfill.VideoUrl = pathFile;//"https://mve.invex.id/storage/video/wedd.mp4";
        //boothfill.VideoUrl = //"https://www.youtube.com/watch?v=hCgTf-rX1Sg4";

        boothfill.TextureLogo = demo.logoTexture;
        int bannerCount = demo.bannerTexture.Count;
        foreach(Texture texture in demo.bannerTexture)
        {
            boothfill.AddBannerTexture(texture);
        }
        
        boothfill.SetUpProps();
        FindObjectOfType<PlayerSpawner>().reSpawn(type);
    }

    public GameObject GetProperty(int typeID, int propId)
    {
        GameObject prop = null;
        switch (typeID)
        {
            case 3:
                prop = property.s_prop[propId - 1];
                gb.OpenSilver();
                break;
            case 2:
                prop = property.g_prop[propId - 1];
                gb.OpenGold();
                break;
            case 1:
                prop = property.p_prop[propId - 1];
                gb.OpenPlatinum();
                break;
        }
        return prop;
    }

    public GameObject GetBooth(int typeID, int standID)
    {
        GameObject booth = null;
        switch (typeID)
        {
            case 3:
                booth = stand.boothSilver[standID - 1];
                break;
            case 2:
                booth = stand.boothGold[standID - 1];
                break;
            case 1:
                booth = stand.boothPlatinum[standID - 1];
                break;
        }

        return booth;
    }
}

[System.Serializable]
public class Stand
{
    public GameObject[] boothSilver;
    public GameObject[] boothGold;
    public GameObject[] boothPlatinum;

    public GameObject[] property;
}


[System.Serializable]
public class Property
{
    public GameObject[] s_prop;
    public GameObject[] g_prop;
    public GameObject[] p_prop;
}

[System.Serializable]
public class DemoGold{
    public Texture logoTexture;
    public List<Texture> bannerTexture;
}