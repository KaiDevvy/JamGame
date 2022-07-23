using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class DialogueSystem : Interactable
{
    public GameObject dialogueObject;
    public TextMeshProUGUI display;
    public Image expressionHolder;
    public Sprite[] expressions;

    private DialogueSequence _currentSequence;
    private Dialogue.Line _currentLine;
    private Coroutine _printing;

    private void Awake()
    {
        StartDialogue("Test");
    }

    public void StartDialogue(string dialogueID)
    {
        dialogueObject.SetActive(true);
        _currentSequence = new DialogueSequence(dialogueID);
        DrawNext();

    }

    public override void ClickEnd()
    { base.ClickEnd();

        DrawNext();
    }

    public void DrawNext()
    {
        if (_currentSequence == null)
            return;


        if (_currentSequence.IsComplete())
        {
            dialogueObject.SetActive(false);
            return;
        }

        _currentLine = _currentSequence.Next();

        if (_currentLine.autoAfter == 0 && _printing != null)
        {
            StopCoroutine(_printing);
            _printing = null;
            display.text = _currentLine?.text ?? "";
            return;
        }

        _printing = StartCoroutine(PrintText());
    }

    private IEnumerator PrintText()
    {
        dialogueObject.SetActive(!_currentLine.hideBox);
        expressionHolder.sprite = expressions[_currentLine.expression];
        expressionHolder.transform.localScale = new Vector3(_currentLine.flipSprite ? -1 : 1, 1, 1);

        WaitForSeconds waitTime = new WaitForSeconds(_currentLine.letterDelay);

        for (int i = 0; i < _currentLine.text.Length; i++)
        {
            display.text = _currentLine.text[..(i+1)];

            yield return waitTime;
        }

        _printing = null;


        if (_currentLine.autoAfter != 0)
        {
            yield return new WaitForSeconds(_currentLine.autoAfter);

            DrawNext();
        }

    }

}