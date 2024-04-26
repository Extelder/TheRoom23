using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAfterTimeScreamer : Screamer
{
    [SerializeField] private float _timeInSeconds;

    private void Awake()
    {
        Scream();
        Invoke(nameof(EndScream), _timeInSeconds);
    }

    public override void EndScream()
    {
        Destroy(gameObject);
    }
}