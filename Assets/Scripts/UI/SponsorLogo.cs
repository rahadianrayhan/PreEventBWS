using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SponsorLogo : MonoBehaviour
{
    RawImage rawImage;
    [SerializeField] Texture[] myTexture;

    [SerializeField] float timeStart;
    private int idx = 0;

    [Header("Countdown")]
    [SerializeField] float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
        timer = timeStart;
        rawImage.texture = myTexture[0];
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (idx < myTexture.Length-1)
            {
                idx++;
            }
            else
            {
                idx = 0;
            }
            rawImage.texture = myTexture[idx];
            timer = timeStart;
        }
    }
}
