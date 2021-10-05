
[System.Serializable]
public static class InputControl
{
    public enum Type
    {
        joystick,
        keyboard
    }

    private static bool pauseState = true;
    public static InputControl.Type CurrentType;

    public static bool PauseState { get => pauseState; set => pauseState = value; }
}