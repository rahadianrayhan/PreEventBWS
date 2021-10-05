using UnityEngine;

public class Webcom : MonoBehaviour
{
    public BoothGenerator booth;
    public GameObject splashScreen;
    public GameObject control;
    public CharacterControl cc;

    private void Awake()
    {
        booth = FindObjectOfType<BoothGenerator>();
    }

    private void Start()
    {
        cc = GameManager.Instance.GetPlayerControl();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OutGame();

            if(Cursor.lockState == CursorLockMode.None)
            {
                OutGame();
            }
            else
            {
                OutGame();
            }
        }

#if UNITY_EDITOR
        DebugKu();
#endif
    }

    private void OutGame()
    {
        cc.controllerPauseState = false;
        cc.ControllerPause();
        //splashScreen.SetActive(true);
        Cursor.visible = true;
        Debug.Log("Get Escape");

        VideoTV video = FindObjectOfType<VideoTV>();
        if(video != null)
        {
            video.StopVideo();
        }
    }

    private void DebugKu()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OpenBooth("AS-06");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OpenBooth("AG-05");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            OpenBooth("AP-01");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            OpenBooth("BG-05");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            OpenBooth("AG-03");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            OpenBooth("AS-08");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            OpenBooth("BS-07");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            OpenBooth("ZG1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            OpenBooth("ZP1");
        }
    }

    public void OpenBooth(string slot)
    {
        booth.Generate(slot);
        //splashScreen.SetActive(false);
        FeatureContainer.instance.CloseAllPanel();
        control.SetActive(true);
        cc.controllerPauseState = false;
        cc.ControllerPause();
    }
}
