using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
public class WordController : MonoBehaviour
{
    public Window window;
    public BoxCollider2D mouseCaptureArea;
    public TextMeshProUGUI textBody;

    private bool _isFocused = false;
    private bool _actComplete = false;
    private string[] essayContent;
    private float essayPosition = 0;

    private void Awake()
    {
        string essay = File.ReadAllText(Application.streamingAssetsPath + "/Misc/AIEssay.txt");

        DialogueSystem.current.OnNextLine += DialogueEvent_NextLine;

        essayContent = essay.Split(" ");
    }

    void OnDestroy() =>
        DialogueSystem.current.OnNextLine -= DialogueEvent_NextLine;
    

    private void DialogueEvent_NextLine(Dialogue.Line line)
    {
        if (line.eventIdentifier == "rewrite")
        {

            _actComplete = true;

            StartCoroutine(RemoveText());

        }

        else if (line.eventIdentifier == "closeWord")
        {
            window.Hide();
            window.isLocked = true;
        }

    }

    private IEnumerator RemoveText()
    {
        for (int i = 0; i < 5; i++)
        {
            essayPosition /= 1.5f;
            textBody.text = string.Join(" ", essayContent[..(int)Mathf.Floor(essayPosition)]);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }

    private void Update()
    {
        if ( !(DialogueSystem.current != null && DialogueSystem.current.IsTalking()) && Input.GetMouseButtonUp(0))
        {
            _isFocused = mouseCaptureArea.bounds.Contains(Mouse.WorldPosition);
        }

        if (_isFocused && Input.anyKeyDown)
        {
            if (Input.GetMouseButtonDown(0) ||
                Input.GetMouseButtonDown(1) ||
                Input.GetMouseButtonDown(2))
                return;

            essayPosition += Random.Range(0.5f, 1);

            int index = (int)Mathf.Floor(essayPosition);
            
            CheckInterrupt(index);

            textBody.text =  string.Join(" ", essayContent[..index]);
            AudioSystem.PlayOneshot("clack", 0.25f);
        }
    }



    private void CheckInterrupt(int index)
    {
        if (_actComplete)
        {
            if (index == 35)
            {

                DialogueSystem.current.StartDialogue("Introduction_End");
                essayPosition = Mathf.Ceil(essayPosition);
                _isFocused = false;
            }


            return;
        }


        switch (index)
        {
            case 5:
                DialogueSystem.current.StartDialogue("Introduction");
                essayPosition = Mathf.Ceil(essayPosition);
                _isFocused = false;
                break;
            case 18:
                DialogueSystem.current.StartDialogue("Introduction2");
                essayPosition = Mathf.Ceil(essayPosition);
                _isFocused = false;
                break;
            case 23:
                DialogueSystem.current.StartDialogue("Introduction3");
                essayPosition = Mathf.Ceil(essayPosition);
                break;
            case 45:
                DialogueSystem.current.StartDialogue("Introduction4");
                essayPosition = Mathf.Ceil(essayPosition);
                _isFocused = false;
                break;

        }
    }
}
