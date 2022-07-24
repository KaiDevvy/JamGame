using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject notification;
    private string _userPath;
    private void Start()
    {
        _userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        DialogueSystem.current.OnDialogueEnd += Dialogue_OnEnd;
        DialogueSystem.current.OnNextLine += Dialogue_NextLine;

    }

    private void Dialogue_OnEnd()
    {
    }

    private void Dialogue_NextLine(Dialogue.Line line)
    {

        switch (line.eventIdentifier)
        {
            case "OpenFiles":
                OSManager.desktopIcons["File Manager"].ClickEnd();
                break;
            case "OpenUser":
                FileManager.instance.PopulateFromPath(_userPath);
                break;
            case "OpenDocuments":
                FileManager.instance.PopulateFromPath(_userPath + "/Documents");
                break;
            case "AntiVirus":
                notification.SetActive(true);
                break;
            case "MegaAngie":
                OSManager.instance.desktopBackground.color = new Color(1, 0, 0, 1);
                break;

        }

    }
}
