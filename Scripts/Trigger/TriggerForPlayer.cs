using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerForPlayer : MonoBehaviour
{
    public UnityEvent OnTriggered;

    private void Awake()
    {
        if (PlayerPrefs.GetInt(gameObject.name, 0) == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerPhysics>(out PlayerPhysics playerPhysics))
        {
            OnTriggered?.Invoke();
            PlayerPrefs.SetInt(gameObject.name, 1);
            Destroy(this);
        }
    }
}