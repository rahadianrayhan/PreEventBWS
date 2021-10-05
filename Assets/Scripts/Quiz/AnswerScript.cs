using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            StartCoroutine(WinCon());
            quizManager.score += 1;
            Debug.Log("Correct");
            quizManager.Correct();
        }
        else
        {
            StartCoroutine(LoseCon());
            Debug.Log("Not Correct");
            quizManager.Correct();
        }
    }

    IEnumerator WinCon()
    {
        quizManager.timeIsRunning = false;
        Debug.Log("WinCOn");
        quizManager.winCon.SetActive(true);
        yield return new WaitForSeconds(2);
        quizManager.winCon.SetActive(false);
        quizManager.timeIsRunning = true;
    }

    IEnumerator LoseCon()
    {
        quizManager.timeIsRunning = false;
        quizManager.loseCon.SetActive(true);
        yield return new WaitForSeconds(2);
        quizManager.loseCon.SetActive(false);
        quizManager.timeIsRunning = true;
    }
}
