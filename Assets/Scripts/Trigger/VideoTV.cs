using UnityEngine;
using UnityEngine.Video;

public class VideoTV : MonoBehaviour
{
#if UNITY_WEBGL || UNITY_ANDROID
    [SerializeField]private YoutubePlayer videoPlayer;
#endif
#if !UNITY_ANDROID
    [SerializeField]private VideoPlayer videoPlayer;
#endif

    [SerializeField] private string videoUrl = "";
    [SerializeField] private FullscreenTrigger fScreenTrigger;


    public void SetUrl(string _url)
    {
        videoUrl = _url;
    }

    public void PlayVideo(ObjectTrigger ot)
    {
        PlayVideoStart();
        ot.gameObject.SetActive(false);
    }

    public void PlayAuto()
    {
        PlayVideoStart();
    }

    private void PlayVideoStart()
    {
        videoPlayer.enabled = true;
#if UNITY_WEBGL || UNITY_ANDROID
        videoPlayer.Play(videoUrl);
#endif
#if !UNITY_ANDROID
        videoPlayer.url = videoUrl;
        videoPlayer.Play();
#endif
        fScreenTrigger.gameObject.SetActive(true);

        Debug.Log(SoundManager.instance.name + "SM");
        
        SoundManager.instance.StopBGM();
    }

    public void StopVideo()
    {
        fScreenTrigger.gameObject.SetActive(false);
        videoPlayer.enabled = false;
        videoPlayer.Stop();
        SoundManager.instance.PlayBGM();
    }
}
