using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScheduleTrigger : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    EventUI eui;

    [Header("Klik Open Menu")]
    public bool isConference;
    public bool isEntertainment;

    private void Start()
    {
        eui = uiManager.schedule.GetComponent<EventUI>();
    }

    private void OnMouseUp()
    {
        if (isConference)
        {
            eui.isConference = true;
            uiManager.OpenUI("schedule");
        }
        if (isEntertainment)
        {
            eui.isConference = false;
            uiManager.OpenUI("schedule");
        }
    }
}
