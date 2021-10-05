using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ContentVideo : MonoBehaviour
{
    [SerializeField]private VideoTV vtv;

    public void SetURL(string url)
    {
        vtv.SetUrl(url);
    }

}
