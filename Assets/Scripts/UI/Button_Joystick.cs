using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Joystick : MonoBehaviour
{
    [SerializeField] private BasicBehaviour behavior;
    [SerializeField] private GameObject buttonSprint;
    [SerializeField] private GameObject buttonWalk;
    [SerializeField] private Joystick leftJoys;
    [SerializeField] private Joystick rightJoys;
    [SerializeField] private TouchLook lookField;

    [SerializeField]private float joysValue;
    public float joysX;
    public float joysV;

    private void Awake()
    {
        behavior = FindObjectOfType<BasicBehaviour>();

        //OnSprint(false);
    }

    public void OnSprint(bool _sprint)
    {
        //buttonSprint.SetActive(!_sprint);
        //buttonWalk.SetActive(_sprint);
        behavior.isSprint = _sprint;
    }

    private void FixedUpdate()
    {
        joysX = AxisInput.GetAxis("Move_h");
        joysV = AxisInput.GetAxis("Move_v");

        joysValue = ((joysX < 0 ? -joysX : joysX) + (joysV < 0 ? -joysV : joysV));

        if (joysValue > 0.98f)
        {
            OnSprint(true);
        }
        else
        {
            OnSprint(false);
        }

    }

    public Joystick Move { get => leftJoys;}
    public Joystick Cam { get => rightJoys; }

    public TouchLook TouchLookField { get => lookField; }
}
