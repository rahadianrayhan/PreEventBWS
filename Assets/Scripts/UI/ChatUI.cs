using System.Collections;
using UnityEngine;

public class ChatUI : MonoBehaviour
{
    public GameObject c_admin;
    public GameObject c_meet;
    public GameObject c_teaser;
    private string number = "6281122336633";

    private bool isCatering = false;
    public ChatTamplate chat;

    public string Number { get => number; set => number = value; }

    public void IsCatering(bool ya)
    {
        isCatering = ya;
        c_teaser.SetActive(ya);
    }

    public void SetUp()
    {
        //number = BoothFill.instances.Phone_number;
        //IsCatering(BoothFill.instances.IsCatering);
    }

    public void CekButton()
    {
        Debug.Log("Button Kliked");
    }

    public void SendChat(string _msg)
    {
        string msg = "";
        switch (_msg)
        {
            case "admin": msg = chat.admin; break;
            case "meet": msg = chat.meet; break;
            case "teaser": msg = chat.teaser; break;
            default: msg = chat.admin; break;
        }

        string url = "https://wa.me/" + number + "?text=" + msg;

#if UNITY_WEBGL && !UNITY_EDITOR
        WebInteraction.OpenWebsite(url);
#endif
#if UNITY_EDITOR
        Application.OpenURL(url);
#endif
    }
}

[System.Serializable]
public class ChatTamplate
{
    public string admin = "Halo,%20saya%20ingin%20bertanya%20tentang%20booth%20anda%20di%20pameran%20Bandung%20Weeding%20Season";
    public string meet = "Halo,%20saya%20ahmad%20ingin%20menjadwalkan%20meeting%20online";
    public string teaser = "Halo,%20saya%20ahmad%20ingin%20melakukan%20food%20teaser%20untuk%20pernikahan%20saya%20pada%20tanggal%2031%20mei%202020";

}