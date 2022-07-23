using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class HoverColor : Interactable
{
    [Header("Hover Settings")]
    public Color hoverColor;

    private Graphic _graphic;
    private Color _startColor;


    private void Awake()
    {
        _graphic = GetComponent<Graphic>();
        _startColor = _graphic.color;
    }


    public override void HoverStart()
    { base.HoverStart();

        _graphic.color = hoverColor;
    }

    public override void HoverEnd()
    { base.HoverEnd();

        _graphic.color = _startColor;
    }
}