using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointerControllerUser : MonoBehaviour
{
    public bool enableHighlightAnimation = true;
    public LayerMask raymask;
    RaycastHit hit;
    Ray ray;
    ObjectTrigger currentTrigger = default(ObjectTrigger);
    void Start()
    {
        
    }

    void Update()
    {
        if (enableHighlightAnimation && !InputControl.PauseState)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10f, raymask))
            {
                if (currentTrigger == default(ObjectTrigger))
                {
                    if (hit.transform.GetComponent<ObjectTrigger>() != null)
                    {
                        currentTrigger = hit.transform.GetComponent<ObjectTrigger>();
                        currentTrigger.OnTriggerHover();
                    } else if (hit.transform.GetComponentInChildren<ObjectTrigger>()) {
                        currentTrigger = hit.transform.GetComponentInChildren<ObjectTrigger>();
                        currentTrigger.OnTriggerHover();
                    }
                }
            }
            else {
                if (currentTrigger != default(ObjectTrigger))
                {
                    currentTrigger.OnTriggerUnhover();
                    currentTrigger = default(ObjectTrigger);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && !InputControl.PauseState) {
            if (GameManager.Instance.isMobile || GameManager.Instance.isWeb)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 10f, raymask))
                {
                    if (hit.transform.GetComponent<ObjectTrigger>() != null)
                    {
                        hit.transform.GetComponent<ObjectTrigger>().OnTriggerClick();
                    } else if (hit.transform.GetComponentInChildren<ObjectTrigger>() != null) {
                        hit.transform.GetComponentInChildren<ObjectTrigger>().OnTriggerClick();
                    }
                }
            }
            /*
            else {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, raymask))
                {
                    Debug.Log("Hit 2 " + hit.transform.name);
                    if (hit.transform.GetComponent<ObjectTrigger>() != null)
                    {
                        hit.transform.GetComponent<ObjectTrigger>().OnTriggerClick();
                    }
                    else if (hit.transform.GetComponentInChildren<ObjectTrigger>() != null)
                    {
                        hit.transform.GetComponentInChildren<ObjectTrigger>().OnTriggerClick();
                    }
                }
            }
            */
        }
    }
}
