using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public bool enableCameraMovement = false;
    public bool controllerPauseState = false;
    public bool playerCanMove = false;
    public bool lockAndHideCursor = false;

    private Rigidbody rb;

    public Vector3 targetAngles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isSettingPose)
        {
            transform.position = targetPose.position;
            transform.localRotation = targetPose.rotation;
            isSettingPose = false;
        }

        if (Input.GetButtonDown("Cancel")) { controllerPauseState = false; playerCanMove = false; ControllerPause(); }
    }

    private void FixedUpdate()
    {
        if (controllerPauseState)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void ControllerPause()
    {
        controllerPauseState = !controllerPauseState;
        InputControl.PauseState = controllerPauseState;
        if (lockAndHideCursor)
        {
            Cursor.lockState = controllerPauseState || GameManager.Instance.isMobile ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = controllerPauseState || GameManager.Instance.isMobile;
        }
    }

    Pose targetPose;
    bool isSettingPose = false;
    public void SetPose(Pose pose)
    {
        isSettingPose = true;
        targetPose = pose;
    }

    public void SetTargetAngles(Vector3 euler)
    {
        targetAngles = euler;
    }
}