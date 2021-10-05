using System.Runtime.InteropServices;
using UnityEngine;

public class ComingSoonUI : MonoBehaviour
{
    bool isOpen = false;
    public GameObject panel;
    public CharacterControl cc;
    public ObjectTrigger currentTrigger;

    private void Start()
    {
        cc = GameManager.Instance.GetPlayerControl();
    }

    void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }
        }
    }

    public void OpenPanel()
    {
        currentTrigger.gameObject.SetActive(false);
        isOpen = true;
        cc.ControllerPause();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        currentTrigger.gameObject.SetActive(true);
        isOpen = false;
        cc.ControllerPause();
        cc.enableCameraMovement = true;
        panel.SetActive(false);
    }
}
