using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SponsorTrigger : MonoBehaviour/*, IPointerClickHandler*/
{
    UIManager uiManager;

    [Header("Klik Open Menu")]
    public bool isVan;
    public bool isBooth;
    public bool isTotem;
    public bool isThanksTo;
    public bool isInformation;

    public int sponsorId;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnMouseUp()
    {
        if (isVan)
        {
            uiManager.OpenPanelUI(uiManager.sponsor, sponsorId);
        }
        if (isBooth)
        {
            uiManager.OpenPanelUI(uiManager.sponsor, sponsorId);
        }
        if (isTotem)
        {
            uiManager.OpenPanelUI(uiManager.sponsor, sponsorId);
        }
        if (isThanksTo)
        {
            uiManager.OpenPanelUI(uiManager.sponsor, sponsorId);
        }
        if (isInformation)
        {
            uiManager.OpenPanelUI(uiManager.info, sponsorId);
        }
    }


    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    Debug.Log("event data :" + eventData.clickCount);
    //    isUIRadio = !isUIRadio;
    //    if (isUIRadio)
    //    {
    //        uiMenuRadio.SetActive(true);
    //    }
    //}
}
