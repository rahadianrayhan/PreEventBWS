using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BoothProps : MonoBehaviour
{
    public TextMeshPro tx_brand;
    public Renderer logoRenderer;
    public List<Renderer> banner;

    public ContentInfo info;
    public ContentVideo video;
    public ContentGuestBook GuestBook;
    public ContentCS cs;
    public ContentCatalog catalog;

    public void SetLogo(Texture texture)
    {
        logoRenderer.material.mainTexture = texture;
    }

    public void SetBanner()
    {
        int i = 0;

        foreach(Renderer rend in banner)
        {
            if( i < BoothFill.instances.textureBanner.Count)
                rend.material.mainTexture = BoothFill.instances.textureBanner[i];
            i = i + 1;
        }
    }

    public void ContentVideo(string _video)
    {
        video.SetURL(_video);
    }

    public void ContentInfo(string _desc, string _web)
    {
        info.SetInfo(_desc, _web);
    }

    public void ContentCs(string _phone, bool isCatering)
    {
        cs.SetPhone(_phone, isCatering);
    }
}
