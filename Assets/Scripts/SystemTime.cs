using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SystemTime : MonoBehaviour
{
    private TextMeshProUGUI _display;

    private readonly WaitForSeconds _waitMinute = new WaitForSeconds(60);

    private void Awake()
    {
        _display = GetComponent<TextMeshProUGUI>();
        _display.SetText(DateTime.Now.ToString("HH:mm"));

        StartCoroutine(TrackTime(60 - DateTime.Now.Second));
    }

    private IEnumerator TrackTime(float startOffset)
    {
        yield return new WaitForSeconds(startOffset);

        
        while (true)
        {
            _display.SetText(DateTime.Now.ToString("HH:mm"));
            yield return _waitMinute;
        }

    }
}
