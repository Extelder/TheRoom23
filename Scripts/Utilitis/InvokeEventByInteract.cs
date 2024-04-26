using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventByInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _destroyScriptAfterInvoke;

    public UnityEvent Event;


    public void Interact()
    {
        Event?.Invoke();
        if (_destroyScriptAfterInvoke)
            Destroy(this);
    }
}