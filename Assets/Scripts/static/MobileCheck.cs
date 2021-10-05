using System.Runtime.InteropServices;

public static class MobileCheck
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public static bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
#if !UNITY_EDITOR && UNITY_ANDROID
        return true;
#endif
        return false;
    }
}
