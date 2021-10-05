using UnityEngine;

public class LandingPage : MonoBehaviour
{
    public GameObject pageHome;
    public GameObject pageBooth;

    public void Start()
    {
        OpenHome();
    }

    public void OpenHome()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        pageHome.SetActive(true);
        pageBooth.SetActive(false);
    }
    
    public void OpenBooth()
    {
        pageBooth.SetActive(true);
        pageHome.SetActive(false);
    }

    public void CloseLandingPage()
    {
        pageBooth.SetActive(false);
        pageHome.SetActive(false);
    }
}
