using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookOnScreamer : Screamer
{
    [SerializeField] private float _delay;

    public UnityEvent OnScream;

    public override void Scream()
    {
        base.Scream();
        GetComponent<BoxCollider>().enabled = false;
        Invoke(nameof(EndScream), _delay);
    }

    public override void EndScream()
    {
        OnScream?.Invoke();
    }
}