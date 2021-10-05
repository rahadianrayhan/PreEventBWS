using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListUI : MonoBehaviour
{
    public GameObject itemList;
    public Transform listparrent;

    [SerializeField]private EventUI eui;

    public List<EventListHelper> list;

    private void Start()
    {
        //GenerateList();
    }

    private void OnEnable()
    {
        foreach (Transform child in listparrent)
        {
            GameObject.Destroy(child.gameObject);
        }

        GenerateList();
    }

    public void GenerateList()
    {
        bool eventConference = eui.isConference;

        foreach (EventListHelper _list in list){

            if (eventConference)
            {
                if (_list.isConference)
                {
                    GameObject itemObj = Instantiate(itemList, listparrent);

                    EventListItem item = itemObj.GetComponent<EventListItem>();
                    item.Detil = eui.GetEventDetil();
                    item.BannerTexture = _list.bannerTexture;
                    item.TimeStart = _list.timeStart;
                    item.TimeEnd = _list.timeEnd;
                    item.Title = _list.title;
                    item.Status = _list.status;
                    item.Desc = _list.desc;
                    item.IsConference = _list.isConference;
                    item.Url = _list.event_url;

                    item.SetItem();
                }
            }
            else
            {
                if (!_list.isConference)
                {
                    GameObject itemObj = Instantiate(itemList, listparrent);

                    EventListItem item = itemObj.GetComponent<EventListItem>();
                    item.Detil = eui.GetEventDetil();
                    item.BannerTexture = _list.bannerTexture;
                    item.TimeStart = _list.timeStart;
                    item.TimeEnd = _list.timeEnd;
                    item.Title = _list.title;
                    item.Status = _list.status;
                    item.Desc = _list.desc;
                    item.IsConference = _list.isConference;
                    item.Url = _list.event_url;

                    item.SetItem();
                }
            }
            
        }
    } 
}

[System.Serializable]
public class EventListHelper{
    public string title;
    public string status;
    public string desc;
    public DateTime timeStart;
    public DateTime timeEnd;
    public bool isConference;
    public Texture bannerTexture;
    public string event_url;

    void Start()
    {
        timeStart = DateTime.Now;
        timeEnd = DateTime.Now;
    }
}