using System.Runtime.InteropServices;
using UnityEngine;

public class WebInteraction : MonoBehaviour
{
#if UNITY_WEBGL
    // Open Web di new Tab
    [DllImport("__Internal")]
    public static extern void OpenWebsite (string urlSite);
#endif
}