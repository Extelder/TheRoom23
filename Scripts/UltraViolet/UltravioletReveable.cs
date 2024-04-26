using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UltravioletReveable : MonoBehaviour
{
    public UnityEvent Reveal;
    public UnityEvent Hide;

    private void Awake()
    {
        Hide?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<UltravioletRevealLampTrigger>(out UltravioletRevealLampTrigger reveal))
        {
            Reveal?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<UltravioletRevealLampTrigger>(out UltravioletRevealLampTrigger reveal))
        {
            Hide?.Invoke();
        }
    }
}