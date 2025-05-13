using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class WindowSettings : MonoBehaviour
{
    [DllImport("user32.dll")] static extern IntPtr GetActiveWindow();
    [DllImport("user32.dll")] static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    [DllImport("user32.dll")] static extern uint GetWindowLong(IntPtr hWnd, int nIndex);
    [DllImport("user32.dll")] static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    [DllImport("user32.dll")] static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
    [DllImport("user32.dll")] static extern bool ReleaseCapture();
    [DllImport("user32.dll")] static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    const int GWL_STYLE = -16;
    const int GWL_EXSTYLE = -20;
    const uint WS_POPUP = 0x80000000;
    const uint WS_VISIBLE = 0x10000000;
    const uint WS_OVERLAPPEDWINDOW = 0x00CF0000;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint LWA_COLORKEY = 0x1;

    const uint WM_NCLBUTTONDOWN = 0x00A1;
    const int HTCAPTION = 0x2;

    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
    const uint SWP_NOSIZE = 0x0001;
    const uint SWP_NOMOVE = 0x0002;
    const uint TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

    bool _showOutline = true;
    IntPtr hwnd;

    void Start()
    {
#if UNITY_STANDALONE_WIN
        hwnd = GetActiveWindow();
        SetBorderless(true);
        SetAlwaysOnTop(true);
        SetTransparentBackground(Color.black);
#endif
    }

    void Update()
    {
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButtonDown(0))
        {
            BeginWindowDrag();
        }
#endif
    }

    void SetBorderless(bool borderless)
    {
        uint newStyle = borderless ? (WS_POPUP | WS_VISIBLE) : (WS_OVERLAPPEDWINDOW | WS_VISIBLE);
        SetWindowLong(hwnd, GWL_STYLE, newStyle);

        uint exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
        SetWindowLong(hwnd, GWL_EXSTYLE, exStyle | WS_EX_LAYERED);

        SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
    }

    void SetAlwaysOnTop(bool topmost)
    {
        SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
    }

    void SetTransparentBackground(Color transparentColor)
    {
        uint colorKey = ((uint)(transparentColor.r * 255) << 16) |
                        ((uint)(transparentColor.g * 255) << 8) |
                        ((uint)(transparentColor.b * 255));
        SetLayeredWindowAttributes(hwnd, colorKey, 0, LWA_COLORKEY);
    }

    void BeginWindowDrag()
    {
        ReleaseCapture();
        SendMessage(hwnd, WM_NCLBUTTONDOWN, HTCAPTION, 0); 
    }
}
