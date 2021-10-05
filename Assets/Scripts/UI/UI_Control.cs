using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    public GameObject panel_joystick;
    public GameObject panel_menu;

    private void Awake()
    {
        PanelMenu(true);

        float a = Screen.width;
    }

    public void PanelMenu(bool _isActive)
    {
        panel_menu.SetActive(_isActive);
    }

    public void PanelJoystick(bool _isActive)
    {
        panel_joystick.SetActive(_isActive);
    }
}
