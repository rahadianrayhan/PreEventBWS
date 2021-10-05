using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class InformationUI : MonoBehaviour
{
    string title;
    string date;
    string time;
    string status;
    string description;

    public TextMeshProUGUI title_name;
    public TextMeshProUGUI text_date;
    public TextMeshProUGUI text_status;
    public TextMeshProUGUI text_description;

    public GameObject list_panel;
    public GameObject detail_panel;
    bool see_detail = true;

    public void Detail()
    {
        list_panel.SetActive(see_detail);
        detail_panel.SetActive(!see_detail);
        see_detail = !see_detail;
    }

    public void SetUp()
    {
        title = "Summer Music Festival";
        date = "28 January 2021";
        time = "10:00 A.M.";
        status = "Live - Youtube";
        description = "Enjoy a week of drums circle, music improvement, camp ground, ukulele workshop and onstage performance for student only.";
        
        title_name.text = name;
        text_date.text = date + " " + time;
        text_status.text = status;
        text_description.text = description;
    }
}
