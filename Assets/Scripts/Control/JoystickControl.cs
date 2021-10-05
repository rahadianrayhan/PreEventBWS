using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    [SerializeField] private Joystick move_joystick;
    [SerializeField] private Joystick cam_joystick;
    [SerializeField] private TouchLook fieldLook;

    private void Awake()
    {
        Button_Joystick joy = FindObjectOfType<UI_Control>().panel_joystick.GetComponent<Button_Joystick>();

        move_joystick = joy.Move;
        cam_joystick = joy.Cam;
        fieldLook = joy.TouchLookField;
    }

    private void Update()
    {
        AxisInput.SetAxis("Move_h", move_joystick.Horizontal);
        AxisInput.SetAxis("Move_v", move_joystick.Vertical);
        /*
        AxisInput.SetAxis("Cam_h", cam_joystick.Horizontal);
        AxisInput.SetAxis("Cam_v", cam_joystick.Vertical);
        */
        AxisInput.SetAxis("Cam_h", fieldLook.Horizontal);
        AxisInput.SetAxis("Cam_v", fieldLook.Vertical);
    }
}
