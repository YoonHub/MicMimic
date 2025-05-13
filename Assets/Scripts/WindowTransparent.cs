using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class WindowTransparent : MonoBehaviour
{
    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x80000;
    const uint WS_EX_TRANSPARENT = 0x20;
    const int LWA_ALPHA = 0x2;
    const int LWA_COLORKEY = 0x1;

    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    void Start()
    {
        IntPtr hwnd = GetActiveWindow();

        int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
        SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | (int)WS_EX_LAYERED);

        SetLayeredWindowAttributes(hwnd, 0x000000, 0, LWA_COLORKEY);
    }
}
