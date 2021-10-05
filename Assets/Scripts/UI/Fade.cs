using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    void Start(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ClosePanelSplash(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}