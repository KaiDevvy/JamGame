using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableIcon : Interactable
{
    public WindowData data;
    private RawImage _image;
    public Window trackedInstance;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

    public void SetLink(Window window)
    {
        trackedInstance = window;
        SetLink(window.data);
    }
    public void SetLink(WindowData data)
    {
        this.data = data;
        _image.texture = data.icon;
    }

    public override void ClickEnd()
    { base.ClickEnd();

        if (data == null || data.locked)
            return;

        if (trackedInstance == null)
        {
            trackedInstance = Instantiate(data.window, OSManager.instance.canvas).GetComponent<Window>();
            trackedInstance.data = data;
            trackedInstance.Show(transform.position);
        }
        else
        {
            trackedInstance.Show(transform.position);
        }
    }

}
