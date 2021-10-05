using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static SceneControl sc;

    private void Awake()
    {
        sc = this;
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void OpenVenue()
    {
        SceneManager.LoadScene("MainVenue");
    }
}
