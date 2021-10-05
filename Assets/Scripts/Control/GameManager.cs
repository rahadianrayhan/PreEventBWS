using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isMobile = false;
    public bool isWeb = false;
    public bool isApk = false;
    public static GameManager Instance;
    public CharacterControl cc;

    public bool PlayerCanMove { get => cc.playerCanMove; set => cc.playerCanMove = value; }

    Pose initPlayerPose;
    private void Awake()
    {
        Instance = this;
        cc = FindObjectOfType<CharacterControl>();
    }

    void Start()
    {
        initPlayerPose.position = cc.transform.position;
        initPlayerPose.rotation = Quaternion.Euler(0, 0, 0);
        Invoke("Init", 0.1f);
    }

    void Init()
    {
        cc.controllerPauseState = false;
        cc.ControllerPause();
    }

    public void SetupMobileEnvironment() {
        cc.enableCameraMovement = false;
        isMobile = true;
        cc.ControllerPause();
    }

    public void SetupDesktopEnvironment() {
        cc.controllerPauseState = true;
        cc.playerCanMove = true;
        cc.ControllerPause();
    }

    void ResetPose() {
        cc.SetPose(initPlayerPose);
    }

    void SetPoseToPos2()
    {
        Pose p = new Pose();
        p.position = new Vector3(-43.44371f,1f, 0.7457692f);
        p.rotation = Quaternion.Euler(0,-90,0);
        cc.SetPose(p);
    }

    public Transform GetPlayer()
    {
        return cc.transform;
    }

    public CharacterControl GetPlayerControl()
    {
        return cc;
    }
}
