using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewWindowData", menuName = "Data/Window")]
public class WindowData : ScriptableObject
{
    public string windowName;
    public Texture2D icon;
    public GameObject window;
    public bool showOnDesktop = true;
    public bool showOnTaskbar = true;


}