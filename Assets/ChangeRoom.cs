using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public bool isBgmPlay = false;

    private void Awake()
    {
        isBgmPlay = SoundManager.instance.BGM.isPlaying;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBgmPlay)
        {
            SoundManager.instance.StopBGM();
            isBgmPlay = false;
        }
        else
        {
            SoundManager.instance.PlayBGM();
            isBgmPlay = true;
        }
    }
}
