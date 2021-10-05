using UnityEngine;
using System.Collections;

public class UI_ControlMenu : MonoBehaviour
{
    public UI_Control ui;

    [SerializeField] private ThirdPersonOrbitCamBasic camOrbit;

    private void Start()
    {
        camOrbit = Camera.main.GetComponent<ThirdPersonOrbitCamBasic>();

#if UNITY_ANDROID
        StartCoroutine(ControlMobile());
#endif
#if UNITY_WEBGL
        // Make Choice Andoird or PC On Going
        bool isMobile = MobileCheck.isMobile();
        if (isMobile)
        {
            StartCoroutine(ControlMobile());
        }
        else
        {
            //Debug.Log("Pilih Control");
        }
#endif
    }

    private IEnumerator ControlMobile()
    {
        yield return new WaitForSeconds(0.5f);
        ChooseControl(1);
    }

    public void ChooseControl(int idx)
    {
        switch (idx)
        {
            case 0:
                // Keyboard and Mouse
                InputControl.CurrentType = InputControl.Type.keyboard;
                ui.PanelJoystick(false);
                camOrbit.horizontalAimingSpeed = 6f;
                camOrbit.verticalAimingSpeed = 6f;
                break;
            case 1:
                // joystick
                InputControl.CurrentType = InputControl.Type.joystick;
                ui.PanelJoystick(true);
                camOrbit.horizontalAimingSpeed = 1f;
                camOrbit.verticalAimingSpeed = 1f;
                break;

        }
        GameManager.Instance.SetupDesktopEnvironment();
        ui.PanelMenu(false);

//        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        ui.PanelMenu(false);
    }
}
