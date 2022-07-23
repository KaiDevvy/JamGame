using UnityEngine;

public class DestroyOnClick : HoverColor
{
    public Window window;

    public override void ClickEnd()
    { base.ClickEnd();

        window.Destroy();
    }
}