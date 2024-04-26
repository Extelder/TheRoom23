using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private GameObject _settings;

    private bool _opened;

    public void Open()
    {
        _opened = true;
        _settings.SetActive(true);
    }

    public void Close()
    {
        _opened = false;
        _settings.SetActive(false);
    }
}