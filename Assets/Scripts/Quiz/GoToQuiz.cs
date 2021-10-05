using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToQuiz : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene("Quiz", LoadSceneMode.Additive);
    }
}
