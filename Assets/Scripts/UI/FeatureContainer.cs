using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureContainer : MonoBehaviour
{
    public bool isOpen = false;
    public PanelContainer comingSoon;
    public PanelContainer info;
    public PanelContainer guest;
    public PanelContainer store;
    public PanelContainer chat;

    public PanelContainer containerActive = null;

    public static FeatureContainer instance;

    private void Awake()
    {
        instance = this;
    }

    public void OpenComingsoon()
    {
        containerActive = comingSoon;
        OpenPanel();
    }

    public void OpenInfo()
    {
        containerActive = info;
        OpenPanel();
    }

    public void OpenGuest()
    {
        containerActive = guest;
        OpenPanel();
    }

    public void OpenStore()
    {
        containerActive = store;
        OpenPanel();
    }

    public void OpenChat()
    {
        containerActive = chat;
        OpenPanel();
    }

    private void OpenPanel()
    {
        if (!isOpen && containerActive != null)
        {
            isOpen = true;
            //containerActive.currentTrigger = ot;
            containerActive.OpenPanel();
        }
    }
/*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            OpenStore();
        }
    }
*/
    public void SetupAll()
    {
        info.GetComponent<InfoUI>().SetUp();
        chat.GetComponent<ChatUI>().SetUp();
    }

    public void ClosePanel()
    {
        isOpen = false;
        containerActive = null;
    }

    public void CloseAllPanel()
    {
        comingSoon.ClosePanel();
        info.ClosePanel();
        guest.ClosePanel();
        store.ClosePanel();
        chat.ClosePanel();
    }
}

public static class ContentFill
{
    private static string information = "";
    private static string web = "";

    public static string Information { get => information; set => information = value; }
    public static string Web { get => web; set => web = value; }
}