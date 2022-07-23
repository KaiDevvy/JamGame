using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : Interactable
{
    [Header("References")]
    public RectTransform affected;

    [Header("Settings")]
    public Vector2 minSize;
    public Vector2 maxSize;


    private Vector2 _startPos;
    private Vector2 _startScale;
    private Vector2 _dragOffset;
    public override void ClickStart()
    { base.ClickStart();

        _startPos = affected.position;
        _startScale = affected.sizeDelta / 2;
        _dragOffset = Mouse.WorldPosition;
    }


    // TODO: This needs to be fixed or removed
    public override void ClickStay()
    { base.ClickStay();

        affected.position = _startPos + (Mouse.WorldPosition - _dragOffset) * 0.5f;
        Vector2 scale = _startScale - ( Mouse.WorldPosition - _dragOffset);
       
        affected.sizeDelta = scale;
    }
}
