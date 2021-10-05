using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class UserProfile : MonoBehaviour
{
    string name;
    string gender;
    string status;
    string location;
    string age;
    string plan;

    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_gender;
    public TextMeshProUGUI text_status;
    public TextMeshProUGUI text_location;
    public TextMeshProUGUI text_age;
    public TextMeshProUGUI text_plan;
    public TextMeshProUGUI title_name;
    public TextMeshProUGUI title_location;
    public TextMeshProUGUI text_button;

    public GameObject edit_panel;
    public GameObject label_panel;
    bool edit_profile = true;

    public void Edit()
    {
        edit_panel.SetActive(edit_profile);
        label_panel.SetActive(!edit_profile);
        edit_profile = !edit_profile;

        text_button.text = (edit_profile? "Edit Profile" : "Save Profile");
    }

    public void SetUp()
    {
        name = "Budi Santoso Altoriq";
        gender = "Male";
        status = "Single";
        location = "Jakarta, Indonesia";
        age = "27";
        plan = "19 March 2021";
        
        title_name.text = name;
        title_location.text = location;
        text_name.text = name;
        text_gender.text = gender;
        text_status.text = status;
        text_age.text = age;
        text_plan.text = plan;
        text_location.text = location;
    }
}
