using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class InfoUI : MonoBehaviour
{
    public string link = "https://invex.id";
    public string information;
    public TextMeshProUGUI text_desc;
    public void OpenLink()
    {
        if (GameManager.Instance.isWeb)
        {
#if !UNITY_EDITOR && UNITY_WEBGL
		WebInteraction.OpenWebsite(link);
#endif
        }
        else
        {
            Debug.Log("open " + link);
            Application.OpenURL(link);
        }
    }

    public void SetUp()
    {
        //information = BoothFill.instances.Information;
        //link = BoothFill.instances.Url_website;

        text_desc.text = information;
    }
}