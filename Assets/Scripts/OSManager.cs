using UnityEngine;
using UnityEngine.UI;

public class OSManager : MonoBehaviour
{
    [Header("Settings")]
    public WindowData[] registeredWindows;

    [Header("References")]
    public Transform canvas;
    public Transform desktopIconPool;
    public Transform taskbarIconPool;
    public GameObject iconPrefab;

    public static OSManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;

        foreach (WindowData window in registeredWindows)
        {
            if (window.showOnDesktop)
            {
                Instantiate(iconPrefab, desktopIconPool)
                    .GetComponent<ClickableIcon>().SetLink(window);
            }
        }
    }
}