using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBooth : MonoBehaviour
{
    public GameObject sPlatinum;
    public GameObject sGold;
    public GameObject sSilver;

    public void OpenPlatinum()
    {
        sGold.SetActive(true);
        sSilver.SetActive(true);
        sPlatinum.SetActive(false);
    }

    public void OpenGold()
    {
        sGold.SetActive(false);
        sSilver.SetActive(true);
        sPlatinum.SetActive(true);
    }
    public void OpenSilver()
    {
        sGold.SetActive(true);
        sSilver.SetActive(false);
        sPlatinum.SetActive(true);
    }
}
