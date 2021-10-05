using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EventDetilUI : MonoBehaviour
{
    [SerializeField] EventUI eui;

    public RawImage banner;
    public TextMeshProUGUI txTitle;
    public TextMeshProUGUI txStatus;
    public TextMeshProUGUI txDesc;
    public TextMeshProUGUI txTime;

    public GameObject buttonLink;

    private string url;

    public void SetDetil(Texture bannerTexture, string title, string status, string desc, string dateTime, bool _isConference, string link)
    {

        banner.texture = bannerTexture;
        txTitle.text = title;
        txStatus.text = status;
        txDesc.text = desc;

        //string t_start = timeStart.ToString();
        //string t_end = timeEnd.ToString();

        //string dateTime = t_start + " s.d. " + t_end;

        txTime.text = dateTime;

        buttonLink.SetActive(_isConference);
        url = link;
    }

    public void OpenLink()
    {
        Application.OpenURL(url);
    }

    public void OpenDetil()
    {
        eui.OpenDetil();
    }

}
