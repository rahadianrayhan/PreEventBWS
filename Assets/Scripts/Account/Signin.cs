using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Signin : MonoBehaviour
{
    private string email = "";
    private string password = "";

    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    public TextMeshProUGUI warningText;

    public TMP_InputField inputUsername;
    public TMP_InputField inputPassword;

    private void Start()
    {
        warningText.text = "";
    }

    public void InitialField(string email, string pwd)
    {
        this.email = email;
        password = pwd;
    }

    public void OnUNEdit()
    {
        email = inputUsername.text;
    }

    public void OnPWEdit()
    {
        password = inputPassword.text;
    }

    public void OnLogin()
    {
        // Do Something
    }

    public void OnLoginFree()
    {
        if (email == "" || email == null)
        {
            warningText.text = "email tidak boleh kosong";
        }
        else if (password == "" || password == null)
        {
            warningText.text = "password salah";
        }
        else if (email == "demo" && password == "demo")
        {
            LoginSuceed();
        }
        else
        {
            warningText.text = "email dan password tidak sesuai";
        }


    }

    public void LoginFacebook()
    {
        // DO Something
        LoginSuceed();
    }

    public void LoginGoogle()
    {
        // DO Something
        LoginSuceed();
    }

    public void LoginSuceed()
    {
        // DO Something
        Debug.Log("Login Success : " + email + "password : " + password);
        warningText.text = "";
#if UNITY_ANDROID
        //changeRotation.Landscape();
        
#endif
        SceneControl.sc.OpenVenue();
    }
}
