using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventByRate : MonoBehaviour
{
    [SerializeField] private float _rate;
    [SerializeField] private bool _activateOnStart;

    public UnityEvent Event;

    private void Start()
    {
        Activate();
    }

    public void Activate()
    {
        StopAllCoroutines();
        StartCoroutine(Invoking());
    }

    public void DisActivate()
    {
        StopAllCoroutines();
    }

    private IEnumerator Invoking()
    {
        while (true)
        {
            Event.Invoke();
            yield return new WaitForSeconds(_rate);
        }
    }
}