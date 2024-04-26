using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventByEndOfTime : MonoBehaviour
{
    [SerializeField] private float _timeInSec;

    public UnityEvent Event;

    private void Start()
    {
        Invoke(nameof(InvokeEvent), _timeInSec);
    }

    private void InvokeEvent()
    {
        Event?.Invoke();
    }
}