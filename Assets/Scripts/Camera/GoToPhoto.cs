using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPhoto : MonoBehaviour
{
    private void OnMouseUp()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene("Photoshot", LoadSceneMode.Additive);
    }
}
