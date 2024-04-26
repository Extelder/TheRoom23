using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventByTriggerPlayerNear : MonoBehaviour
{
    public UnityEvent Event;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerNear>(out PlayerNear near))
        {
            Event?.Invoke();
        }
    }
}