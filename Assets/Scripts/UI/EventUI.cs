using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUI : MonoBehaviour
{
    [SerializeField] private GameObject listView;
    [SerializeField] private GameObject detilView;

    public bool isConference;

    public void OpenList()
    {
        listView.SetActive(true);
        detilView.SetActive(false);
    }

    public void OpenDetil()
    {
        listView.SetActive(false);
        detilView.SetActive(true);
    }

    public EventDetilUI GetEventDetil()
    {
        return detilView.GetComponent<EventDetilUI>();
    }
}
