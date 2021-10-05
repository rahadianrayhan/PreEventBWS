using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TriggerButton : MonoBehaviour
{
    public GameObject button;
    public VideoPlayer videos;

    public bool played = false;

    private void Awake()
    {
        string pathFile = System.IO.Path.Combine(Application.streamingAssetsPath, "bws-greeting.mp4"); ;
        videos.url = pathFile;
    }

    private IEnumerator Initial()
    {
        yield return new WaitForSeconds(0.5f); 
        videos.SetDirectAudioVolume(0, 0f);
        videos.Play();
        
        yield return new WaitForSeconds(3f);

        videos.Stop();
        videos.SetDirectAudioVolume(0, 1f);
    }

    private void Start()
    {
        StartCoroutine(Initial());
    }

    //public void ShowButton(bool _isShow)
    //{
    //    button.SetActive(_isShow);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player" && !loops)
    //    {
    //        ShowButton(true);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //ShowButton(false);
            if(videos.GetDirectAudioVolume(0) < 1)
                videos.SetDirectAudioVolume(0, 1f);

            videos.Play();
        }

        Debug.Log("Stay with " + other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            //ShowButton(false);

            videos.Stop();
        }

        Debug.Log("Exit with " + other.name);
    }
}
