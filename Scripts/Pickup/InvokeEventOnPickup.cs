using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventOnPickup : MonoBehaviour, IPickuptable
{
    public UnityEvent Event;

    public void Pickup()
    {
        Event?.Invoke();
        Destroy(gameObject);
    }
}