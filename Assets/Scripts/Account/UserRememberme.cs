using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserRememberme : MonoBehaviour
{
    public TMP_InputField tx_email;
    public TMP_InputField tx_password;
    public Toggle remember_me;

    string email_key = "email";
    string password_key = "password";
    string remember_key = "remember";

    private void Awake()
    {
        LoadRememberPref();
    }
    private void Update()
    {

    }
    public void OnChangeRemember()
    {
        UserAccount.Email = tx_email.text;
        UserAccount.Password = tx_password.text;
        if (remember_me.isOn)
        {
            UserAccount.Remember = true;
            SaveRememberPref(UserAccount.Remember, UserAccount.Email, UserAccount.Password);
            //Debug.Log("Save  | " + UserAccount.Email + " " + UserAccount.Password + " " + UserAccount.Remember);
        }
        else
        {
            UserAccount.Remember = false;
            SaveRememberPref(UserAccount.Remember, "", "");
            Debug.Log("Save  | " + " | not remember");
        }
    }

    public void SaveRememberPref(bool remember, string email, string password)
    {
        if (remember) {
            PlayerPrefs.SetInt(remember_key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(remember_key, 0);
        }

        PlayerPrefs.SetString(email_key, email);
        PlayerPrefs.SetString(password_key, password);
        PlayerPrefs.Save();

    }

    public void LoadRememberPref()
    {
        int remember_id = PlayerPrefs.GetInt(remember_key, 0);
        switch (remember_id)
        {
            case 0:
                UserAccount.Remember = false;
                break;
            case 1:
                UserAccount.Remember = true;
                break;
            default:
                UserAccount.Remember = false;
                break;
        }

        UserAccount.Email = PlayerPrefs.GetString(email_key);
        UserAccount.Password = PlayerPrefs.GetString(password_key);

        UpdateField(UserAccount.Email, UserAccount.Password, UserAccount.Remember);
        //Debug.Log("Load  | " + UserAccount.Email + " " + UserAccount.Password + " " + UserAccount.Remember);
    }

    private void UpdateField(string email, string password, bool remember)
    {
        remember_me.isOn = remember;
        tx_email.text = email;
        tx_password.text = password;

        FindObjectOfType<Signin>().InitialField(email, password);
    }
}
