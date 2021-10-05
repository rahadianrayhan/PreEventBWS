using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class Galery : MonoBehaviour
{
    PhoneCam phoneCam;
    public GameObject showGalery;
    public GameObject canvas;
    string[] files = null;
    int whichScreenShotIsShow = 0;

    public void ShowGalery(bool i)
    {
        showGalery.SetActive(i);
        files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
        if (files.Length > 0)
        {
            GetPictureAndShowIt();
        }
    }

    public void CloseGalery(bool i)
    {
        showGalery.SetActive(i);
    }

    void GetPictureAndShowIt()
    {
        string pathToFile = files[whichScreenShotIsShow];
        Texture2D texture = GetScreenShotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
        canvas.GetComponent<Image>().sprite = sp;  
    }

    Texture2D GetScreenShotImage(string filepath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filepath))
        {
            fileBytes = File.ReadAllBytes(filepath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }

    public void NextPict()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShow += 1;
            if(whichScreenShotIsShow > files.Length - 1)
            {
                whichScreenShotIsShow = 0;
            }
            GetPictureAndShowIt();
        }
    }

    public void BackPict()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShow -= 1;
            if (whichScreenShotIsShow < 0)
            {
                whichScreenShotIsShow = files.Length - 1;
            }
            GetPictureAndShowIt();
        }
    }

    public void GoToMain()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        if(phoneCam.backCam.isPlaying)
        {
            phoneCam.GetComponent<PhoneCam>().backCam.Stop();
        }       
        SceneManager.UnloadSceneAsync("Photoshot");
    }
}
