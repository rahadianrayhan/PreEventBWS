using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPortofolioView : MonoBehaviour
{
    public RawImage images;
    public TMPro.TextMeshProUGUI textName;

    public void CloseView()
    {
        gameObject.SetActive(false);
    }

    public void OpenView(string _n, Texture _t)
    {
        images.texture = _t;
        textName.text = _n;

        gameObject.SetActive(true);
    }
}
