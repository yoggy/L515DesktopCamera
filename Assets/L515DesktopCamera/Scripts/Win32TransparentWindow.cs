using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Win32TransparentWindow : MonoBehaviour
{
    [DllImport("User32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("User32.dll")]
    private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("User32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("User32.dll")]
    private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("User32.dll")]
    private static extern Boolean SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

    const int GWL_STYLE = -16;
    const int GWL_EXSTYLE = -20;
    const uint WS_POPUP = 0x80000000;
    const uint WS_EX_LAYERD = 0x080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;

    IntPtr HWND_TOPMOST = new IntPtr(-1);
    const uint SWP_NOSIZE = 0x0001;
    const uint SWP_NOMOVE = 0x0002;
    const uint SWP_NOACTIVE = 0x0010;
    const uint SWP_SHOWWINDOW = 0x0040;

    const int LWA_COLORKEY = 0x1;

    IntPtr hWnd;
    private uint oldWindowStyle;
    private uint oldWindowExStyle;

    void Awake()
    {
        hWnd = GetActiveWindow();

        oldWindowStyle = GetWindowLong(hWnd, GWL_STYLE);
        oldWindowExStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
    }

    public void EnableWindowTransparent()
    {
        //SetWindowLong(hWnd, GWL_STYLE, WS_POPUP);
        SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERD | WS_EX_TRANSPARENT);

        SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVE | SWP_SHOWWINDOW);
    }

    public void DisableWindowTransparent()
    {
        SetWindowLong(hWnd, GWL_STYLE, oldWindowStyle);
        SetWindowLong(hWnd, GWL_EXSTYLE, oldWindowExStyle);
    }
}
