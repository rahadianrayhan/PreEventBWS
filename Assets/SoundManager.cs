using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioClip bgm;
    public string radioUrl;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;

        SetBGM();
        //SetRadio();
    }

    private void Start()
    {
        PlayBGM();
    }

    public void SetBGM()
    {
        BGM.clip = bgm;
    }

    public void SetRadio()
    {
        Debug.Log("Set Radio ...");
        StartCoroutine(Radio());
    }

    private IEnumerator Radio()
    {
        Debug.Log("Radio ...");
        UnityWebRequest music = UnityWebRequestMultimedia.GetAudioClip(radioUrl, AudioType.MPEG);
        yield return music.SendWebRequest();

        Debug.Log("Radio Dapet ...");

        if (music.isNetworkError)
        {
            Debug.Log(music.error);
        }
        else
        {
            Debug.Log("Radio ... di Clip");
            AudioClip clip = DownloadHandlerAudioClip.GetContent(music);
            Debug.Log(clip + " length: " + clip.length);
            if (clip)
            {
                BGM.clip = clip;
                BGM.Play();
            }
        }
    }

    public void PlayBGM()
    {    
        BGM.Play();
    }

    public void StopBGM()
    {
        Debug.Log(BGM.name);
        BGM.Stop();
    }
}
