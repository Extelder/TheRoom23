using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdvice : MonoBehaviour
{
    [SerializeField] private PlayerAdviceUI _adviceUi;

    public static PlayerAdvice Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void ShowAdvice(string text)
    {
        _adviceUi.ShowAdvice(text);
    }
}