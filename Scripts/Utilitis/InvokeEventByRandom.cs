using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class InvokeEventByRandom : MonoBehaviour
{
    [SerializeField] private float _chance;
    [SerializeField] private float _rate;

    public UnityEvent Event;

    private void Start()
    {
        StartCoroutine(Invoking());
    }

    private IEnumerator Invoking()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, _chance) * _rate);
            Event?.Invoke();
        }
    }
}