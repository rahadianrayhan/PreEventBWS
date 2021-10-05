using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAuto : MonoBehaviour
{
    private ObjectTrigger ot;

    private void Start()
    {
        ot = GetComponent<ObjectTrigger>();
    }

    public void AutoPlay()
    {
        ot.OnTriggerClick();
    }
}
