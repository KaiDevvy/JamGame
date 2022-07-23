using UnityEngine;



public abstract class Interactable : MonoBehaviour
{
    public virtual void ClickStart() { }
    public virtual void ClickStay() { }
    public virtual void ClickEnd() { }

    public virtual void HoverStart() { }
    public virtual void HoverEnd() { }

    public virtual void Lock() { }
    public virtual void Unlock() { }




}