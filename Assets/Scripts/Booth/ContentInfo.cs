using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentInfo : MonoBehaviour
{
    private string desc;
    private string web;

    private InfoUI infoUI;
    private void Awake()
    {
        infoUI = FindObjectOfType<InfoUI>();
    }

    public void SetInfo(string _desc, string _web)
    {
        desc = _desc;
        web = _web;

        infoUI.information = _desc;
        infoUI.link = _web;

        infoUI.SetUp();
    }


}
