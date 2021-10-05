using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public CharacterControl cc;

    public GameObject user;
    public GameObject schedule;
    public GameObject info;
    public GameObject sponsor;
    public GameObject[] sponsor_detil;

    UIPanel temp;

    private void Start()
    {
        cc = GameManager.Instance.GetPlayerControl();
    }

    public void OpenPanelUI(GameObject obj, int sponsorId)
    {
        cc.ControllerPause();
        UIPanel uiPanel = obj.GetComponent<UIPanel>();
        setActive(uiPanel.panel);
        temp = uiPanel;
        if (sponsorId >=0)
        {
            sponsor_detil[sponsorId].SetActive(true);
        }
    }

    public void OpenUI(string obj)
    {
        cc.ControllerPause();
        UIPanel uiPanel = null;

        switch (obj)
        {
            case "user":
                uiPanel = user.GetComponent<UIPanel>();
                break;
            case "schedule":
                uiPanel = schedule.GetComponent<UIPanel>();
                break;
            case "info":
                uiPanel = info.GetComponent<UIPanel>();
                break;
        }

        setActive(uiPanel.panel);
        temp = uiPanel;
    }

    public void DeactiveCC()
    {
        setNonActive(temp.panel);
        cc.ControllerPause();
    }

    public void setActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void setNonActive(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("keluar!");
        Application.Quit();
    }
}
