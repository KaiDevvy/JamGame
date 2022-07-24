using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance;

    public Interactable _currentInteractable;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            AudioSystem.PlayOneshot("click", 0.25f);

        if (_currentInteractable != null)
        {
            if (Input.GetMouseButtonDown(0))
                _currentInteractable.ClickStart();


            else if (Input.GetMouseButtonUp(0))
                _currentInteractable.ClickEnd();


            if (Input.GetMouseButton(0))
                _currentInteractable.ClickStay();

        }

        UpdateInteractable();

    }

    private void UpdateInteractable()
    {
        if (Input.GetMouseButton(0))
            return;

        RaycastHit2D hit;
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        Interactable hitInteractable = hit.transform?.GetComponent<Interactable>();

        if (hitInteractable != _currentInteractable)
        {
            if (_currentInteractable != null)
                _currentInteractable.HoverEnd();

            _currentInteractable = hitInteractable;

            if (_currentInteractable != null)
                _currentInteractable.HoverStart();
        }
    }
}
