using System.IO;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class FileManager : MonoBehaviour
{
    public GameObject filePrefab;
    public Transform filePool;

    private void Awake()
    {
        PopulateFromPath("C:/");
    }

    public void PopulateFromPath(string path)
    {
        string[] folders = Directory.GetDirectories(path);
        for (int i = 0; i < folders.Length; i++)
        {
            if (i >= 25)
                break;

            string folder = folders[i];
            string folderName = Path.GetFileName(folder).Truncate(8);

            Instantiate(filePrefab, filePool).GetComponentInChildren<TextMeshProUGUI>().SetText(folderName);
        }

    }
}