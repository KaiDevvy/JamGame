using UnityEngine;
using UnityEngine.UI;

// Class for testing that InteractionManager is working correctly

[RequireComponent(typeof(Graphic))]
public class InteractableTest : Interactable
{
    private Graphic _graphic;

    private void Awake()
    {
        _graphic = GetComponent<Graphic>();
    }

    public override void HoverStart()
    { base.HoverStart();

        _graphic.color = Color.red;
    }
    public override void HoverEnd()
    { base.HoverEnd();

        _graphic.color = Color.white;
    }

    public override void ClickStart()
    { base.ClickStart();

        transform.localScale = Vector3.one * 2;
    }

    public override void ClickEnd()
    { base.ClickEnd();

        transform.localScale = Vector3.one;
    }
}