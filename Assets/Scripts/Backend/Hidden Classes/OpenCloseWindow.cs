﻿using System.Collections.Generic;
using UnityEngine;

internal static class OpenCloseWindow
{
    static OpenCloseWindow()
    {
        UIApi.OnWindowOpen += OpenWindow;
        UIApi.OnCloseLastWindow += CloseLastWindow;
        UIApi.OnCloseAllWindows += CloseAllWindows;
    }

    private static void OpenWindow(GameObject window)
    {
        GameObject windowObj = Object.Instantiate(window, window.transform.position, Quaternion.identity);
        UIApi.OpenedWindows.Add(windowObj);
    }

    private static void CloseLastWindow(GameObject window)
    {
        Object.Destroy(window);
		UIApi.OpenedWindows.RemoveAt(UIApi.OpenedWindows.Count - 1);
    }

    private static void CloseAllWindows(List<GameObject> windows)
    {
        for (int i = 0; i < windows.Count; i++)
        {
            Object.Destroy(windows[i]);
        }

		UIApi.OpenedWindows.Clear();
	}
}
