using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenTrigger : MonoBehaviour
{
    [Header("Klik Open Menu")]
    public bool isFullScreen = false;
    ThirdPersonOrbitCamBasic camScript;

    public float distCamZ = -3f;
    public float distCamX = 0f;
    public float rotCamY = -180f;
    [SerializeField] private GameObject canvasUI;

    private Vector3 tPos;
    private Vector3 tRot;

    private void Awake()
    {
        camScript = Camera.main.GetComponent<ThirdPersonOrbitCamBasic>();

        canvasUI = FindObjectOfType<UI_Control>().gameObject;
    }

    private void OnMouseDown()
    {
        if (!isFullScreen)
        {
            camScript.enabled = false;

            tPos = Camera.main.transform.position;
            tRot = Camera.main.transform.localEulerAngles;

            Camera.main.transform.position = new Vector3(transform.position.x + distCamX, transform.position.y, transform.position.z + distCamZ);
            Camera.main.transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + rotCamY, 0);
        }
        else
        {
            
            Camera.main.transform.position = tPos;
            Camera.main.transform.localEulerAngles = tRot;

            camScript.enabled = true;
        }
        canvasUI.SetActive(isFullScreen);
        isFullScreen = !isFullScreen;
    }
}
