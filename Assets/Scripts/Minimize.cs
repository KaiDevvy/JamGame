using UnityEngine;
using UnityEngine.UI;

public class Minimize : HoverColor
{
    public Window window;
    public override void ClickEnd()
    { base.ClickEnd();

        window.Hide();
    }
}