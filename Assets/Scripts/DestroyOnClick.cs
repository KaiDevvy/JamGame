using UnityEngine;

public class DestroyOnClick : HoverColor
{
    public Window window;
    public GameObject alternate;

    public override void ClickEnd()
    { base.ClickEnd();
        if (window != null)
            window.Destroy();

        else
            Destroy(alternate);
    }
}