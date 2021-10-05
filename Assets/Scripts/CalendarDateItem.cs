using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CalendarDateItem : MonoBehaviour {

    public CalendarController controler;

    public void OnDateItemClick()
    {
        controler.OnDateItemClick(gameObject.GetComponentInChildren<Text>().text);
    }
}
