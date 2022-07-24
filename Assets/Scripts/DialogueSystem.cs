using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using TMPro;


public class DialogueSystem : Interactable
{
    public static DialogueSystem current;
    public GameObject dialogueObject;
    public TextMeshProUGUI display;
    public Image expressionHolder;
    public Sprite[] expressions;

    private DialogueSequence _currentSequence;
    private Dialogue.Line _currentLine;
    private Coroutine _printing;


    public event DialogueEvent OnNextLine;
    public event Action OnDialogueEnd;

    private void Awake()
    {
        current = this;
        gameObject.SetActive(false);
    }

    public bool IsTalking()
    {
        return _printing != null;
    }

    public void StartDialogue(string dialogueID)
    {
        gameObject.SetActive(true);
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
            OnDialogueEnd?.Invoke();
            return;
        }


        if (_printing != null)
        {
            /*
            StopCoroutine(_printing);
            _printing = null;
            display.text = _currentLine?.text ?? ""; */
            return;
        }
        
        _currentLine = _currentSequence.Next();

        OnNextLine?.Invoke(_currentLine);
        _printing = StartCoroutine(PrintText());
    }

    private IEnumerator PrintText()
    {
        dialogueObject.SetActive(!_currentLine.hideBox);
        expressionHolder.sprite = expressions[_currentLine.expression];
        expressionHolder.transform.localScale = new Vector3(_currentLine.flipSprite ? -1 : 1, 1, 1);

        WaitForSeconds waitTime = new WaitForSeconds(_currentLine.letterDelay);

        for (int i = 0; i < _currentLine.text.Length+1; i++)
        {
            display.text = _currentLine.text[..(i)] + "<alpha=#00>" + _currentLine.text[(i)..];

            yield return waitTime;
        }

        _printing = null;


        if (_currentLine.autoAfter != 0)
        {
            yield return new WaitForSeconds(_currentLine.autoAfter);

            DrawNext();
        }

    }

    public delegate void DialogueEvent(Dialogue.Line line);

}