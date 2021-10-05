using UnityEngine;

public class PageControl : MonoBehaviour
{
    public GameObject panelLogin;
    public GameObject panelRegister;

    private void Awake()
    {
        OpenLogin();
    }

    public void OpenLogin()
    {
        panelRegister.SetActive(false);
        panelLogin.SetActive(true);
    }

    public void OpenRegister()
    {
        panelLogin.SetActive(false);
        panelRegister.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenLogin();
        }
    }
}
