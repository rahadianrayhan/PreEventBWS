using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QnA;
    public GameObject[] option;
    public int currentQuestion;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject endPanel;
    public GameObject winCon;
    public GameObject loseCon;

    public Text questionText;
    public Text scoreText;
    public int totalQuestion = 0;
    public int score = 0;

    public float timeRemaining = 60;
    public bool timeIsRunning;
    public Text T;

    // Start is called before the first frame update
    void Start()
    {
        totalQuestion = QnA.Count;
        GenerateQuestion();
        startPanel.SetActive(true);
        mainPanel.SetActive(false);
        endPanel.SetActive(false);
        winCon.SetActive(false);
        loseCon.SetActive(false);
        timeIsRunning = false;
    }

    private void FixedUpdate()
    {
        Timer();
    }

    public void Gameover()
    {
        timeRemaining = 0;
        timeIsRunning = false;
        mainPanel.SetActive(false);
        endPanel.SetActive(true);
        winCon.SetActive(false);
        loseCon.SetActive(false);
        scoreText.text = score + " / " + totalQuestion;
    }

    public void Go()
    {
        startPanel.SetActive(false);
        mainPanel.SetActive(true);
        endPanel.SetActive(false);
        winCon.SetActive(false);
        loseCon.SetActive(false);
        timeIsRunning = true;
    }

    public void Correct()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnswer()
    {
        for (int i = 0; i < option.Length; i++)
        {
            option[i].GetComponent<AnswerScript>().isCorrect = false;
            option[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];

            if(QnA[currentQuestion].correctAnswer == i + 1)
            {
                option[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void Timer()
    {
        if(timeIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("End");
                Gameover();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        T.text = string.Format("{0:00}:{1:00}", minute, seconds);
    }

    void GenerateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            questionText.text = QnA[currentQuestion].question;

            SetAnswer();
        }
        else
        {
            Debug.Log("Out of question");
            Gameover();
        }
    }

    public void Unscene()
    {
        SceneManager.UnloadSceneAsync("Quiz");
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(10);
    }
    
}
