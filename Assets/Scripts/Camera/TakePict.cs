using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePict : MonoBehaviour
{
    public GameObject[] UI;

    public void TakeAPicture()
    {
        StartCoroutine(CaptureIt());
    }

    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = "Screenshot" + timeStamp + ".png";
        string pathToSave = fileName;
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(false);
        }
        ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForSeconds(2);
        for (int i = 0; i < UI.Length; i++)
        {
            UI[i].SetActive(true);
        }
        yield return new WaitForEndOfFrame();
    }
}
