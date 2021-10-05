using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    [Header("Send Message To Target Object")]
    public bool targetOpenStore = false;
    public bool targetInfoTrigger = false;
    public bool targetChat = false;
    public bool targetGuest = false;
    public bool targetVideo = false;
    public GameObject target;
    public string functionName = "PlayVideo";

    [Header("Toggle With Other Object")]
    public GameObject objectToToggleTo;

    public bool isComingSoon = true;

    public bool hover = false;
    public bool active = true;
    Vector3 initialScale;
    Vector3 hoverScale;
    FeatureContainer feature;
    /*
    StoreUI sui;
    InfoUI iui;
    ChatUI cui;
    GuestUI gui;
    ComingSoonUI csui;
    */
    private void Start()
    {
        if (!targetVideo)
        {
            feature = FindObjectOfType<FeatureContainer>();
            target = feature.gameObject;
        }

        if (targetOpenStore)
        {
            functionName = "OpenStore";
        }
        if (targetInfoTrigger)
        {
             functionName = "OpenInfo";
        }
        if (targetChat)
        {
            functionName = "OpenChat";
        }
        if (targetGuest)
        {
            functionName = "OpenGuest";
        }
        if (isComingSoon)
        {
            functionName = "OpenComingsoon";
        }
        initialScale = transform.localScale;
        hoverScale = initialScale * 1.5f;
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (active)
        {
            if (hover)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, hoverScale, Time.deltaTime * 3f);
            }
            else
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, initialScale, Time.deltaTime * 3f);
            }
        }
    }


    public void OnTriggerClick() {
        if (target != null)
        {
            if(functionName!= "PlayVideo")
            {
                target.SendMessage(functionName);
            }
            else
            {
                target.SendMessage(functionName, this);
            }
            
        }

        if (objectToToggleTo != null) {
            ToggleWithOther();
        }
    }

    public void ToggleWithOther() {
        objectToToggleTo.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void OnTriggerHover() {
        hover = true;
    }
    public void OnTriggerUnhover()
    {
        hover = false;
    }

    public void OnTriggerActivate()
    {
        active = true;
        transform.localScale = Vector3.zero;
    }

    Coroutine c;
    public void OnTriggerDeactivate()
    {
        active = false;
        if (c != null) StopCoroutine(c);
        c = StartCoroutine(DoDeactivate());
    }

    IEnumerator DoDeactivate() {

        float t = 0;
        while (t < 1f) {
            t += Time.deltaTime * 3f;
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 3f);
            yield return null;
        }
        yield return null;
        this.gameObject.SetActive(false);
    }
}
