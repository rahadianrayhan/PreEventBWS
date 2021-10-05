using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventListItem : MonoBehaviour, IPointerClickHandler
{

    public RawImage banner;
    public TextMeshProUGUI txTitle;
    public TextMeshProUGUI txShortDesc;

    [SerializeField]private EventDetilUI detil;
    private Texture bannerTexture;
    private string title;
    private DateTime timeStart; // Time Start
    private DateTime timeEnd; // Time End
    private string status; // live or Zoom
    private string desc; // description
    private string dateTime;
    private bool isConference;
    private string url;

    public Texture BannerTexture { get => bannerTexture; set => bannerTexture = value; }
    public string Title { get => title; set => title = value; }
    public DateTime TimeStart { get => timeStart; set => timeStart = value; }
    public DateTime TimeEnd { get => timeEnd; set => timeEnd = value; }
    public string Status { get => status; set => status = value; }
    public string Desc { get => desc; set => desc = value; }
    public EventDetilUI Detil { get => detil; set => detil = value; }
    public bool IsConference { get => isConference; set => isConference = value; }
    public string Url { get => url; set => url = value; }

    public void SetItem()
    {
        banner.texture = bannerTexture;
        txTitle.text = title;

        string t_start = timeStart.ToString();
        string t_end = timeEnd.ToString();

        dateTime = t_start + " s.d. " + t_end;

        txShortDesc.text = dateTime + "\n" + status;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {
        detil.SetDetil(bannerTexture, title, status, desc, dateTime, isConference, url);

        detil.OpenDetil();

        yield return null;
    }
}
