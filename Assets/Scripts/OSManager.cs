using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OSManager : MonoBehaviour
{
    [Header("Settings")]
    public WindowData[] registeredWindows;

    [Header("References")]
    public Transform canvas;
    public Transform desktopIconPool;
    public Transform taskbarIconPool;
    public Graphic desktopBackground;
    public GameObject iconPrefab;

    public static OSManager instance;
    public static Dictionary<string, ClickableIcon> desktopIcons = new Dictionary<string, ClickableIcon>();

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;

        foreach (WindowData window in registeredWindows)
        {
            if (window.showOnDesktop)
            {
                ClickableIcon icon = Instantiate(iconPrefab, desktopIconPool)
                    .GetComponent<ClickableIcon>();

                icon.SetLink(window);

                desktopIcons.Add(window.windowName, icon);
            }
        }
    }
}