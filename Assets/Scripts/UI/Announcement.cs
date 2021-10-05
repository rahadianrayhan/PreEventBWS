using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Announcement : MonoBehaviour
{
    [SerializeField] private float timeStart;
    private RectTransform transObject;
    public TextMeshProUGUI txtAnnoun;

    public RunningTextPromo rText;
    private string currentText;
    private RectTransform startPos;
    private int currentIdx = 0;

    [SerializeField] private float scrollspeed = 1f;
    [SerializeField] private float maxScroll = -4200f;

    private float timer = 0f;
    

    void Start()
    {
        timer = timeStart;
        transObject = txtAnnoun.GetComponent<RectTransform>();
        startPos = transObject;
        UpdateText();
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if(transObject.anchoredPosition.x > maxScroll)
                transObject.anchoredPosition -= Vector2.right * scrollspeed * Time.deltaTime;
        }
        else
        {
            if (currentIdx < rText.text.Count - 1)
            {
                currentIdx += 1;
                UpdateText();
                timer = timeStart;
            }
            else
            {
                currentIdx = 0;
                UpdateText();
                timer = timeStart;
            }
        }
    }

    private void UpdateText()
    {
        currentText = rText.GetText(currentIdx);
        txtAnnoun.text = currentText;
        transObject.anchoredPosition = Vector2.zero;
    }
}

[System.Serializable]
public class RunningTextPromo
{
    public List<string> text = new List<string>();

    public string GetText(int idx)
    {
        return text[idx];
    }
} 
