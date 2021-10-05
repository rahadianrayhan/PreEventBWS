using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Announcement_Bckp : MonoBehaviour
{
    [SerializeField] GameObject movingAnnouncer;
    [SerializeField] float timeStart;
    [SerializeField] Animator animator;
    
    public TextMeshProUGUI txtAnnoun;

    [Header("Countdown")]
    [SerializeField] float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        timer = timeStart;
        animator = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0)
        {
            //animator.SetTrigger("Announce");
            timer = timeStart;
        }
        
    }
}
