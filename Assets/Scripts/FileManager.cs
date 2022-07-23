using System.IO;
using UnityEngine;
using TMPro;

public class FileManager : MonoBehaviour
{
    public GameObject filePrefab;
    public Transform filePool;

    private void Awake()
    {
        PopulateFromPath("C:/Users/kaiso/Documents/UnityProjects/JamGame");
    }

    public void PopulateFromPath(string path)
    {
        foreach (string folder in Directory.GetDirectories(path))
        {
            Instantiate(filePrefab, filePool).GetComponentInChildren<TextMeshProUGUI>().SetText(Path.GetFileName(folder));
        }

    }
}