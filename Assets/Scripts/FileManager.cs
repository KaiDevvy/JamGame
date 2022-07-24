using System.IO;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class FileManager : MonoBehaviour
{
    public static FileManager instance;
    public GameObject filePrefab;
    public Transform filePool;

    private void Awake()
    {
        instance = this;
        PopulateFromPath(Path.GetPathRoot(Application.dataPath));
    }

    public void PopulateFromPath(string path)
    {
        ClearChildren(filePool);
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

    private void ClearChildren(Transform parent)
    {
        var tempList = parent.Cast<Transform>().ToList();
        foreach (Transform child in tempList)
                Destroy(child.gameObject);
            
    }
}