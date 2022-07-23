using UnityEngine;

public class Draggable : Interactable
{
    public Transform dragObject;
    private Vector2 _dragOffset;

    public override void ClickStart()
    { base.ClickStart();

        _dragOffset = dragObject.position - (Vector3) Mouse.WorldPosition;
    }

    public override void ClickStay()
    { base.ClickStay();

        dragObject.position = Mouse.WorldPosition + _dragOffset;

    }

}