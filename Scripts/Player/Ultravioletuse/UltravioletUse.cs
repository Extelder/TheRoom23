using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltravioletUse : MonoBehaviour
{
    [SerializeField] private GameObject _ultravioletStick;

    private PlayerControls _controls;

    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.UltravioletStickUse.performed += context => SetAnotherActive();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void SetAnotherActive()
    {
        if (_ultravioletStick.activeSelf)
            DisActivate();
        else
            Activate();
    }

    public void Activate()
    {
        _ultravioletStick.SetActive(true);
    }

    public void DisActivate()
    {
        _ultravioletStick.SetActive(false);
    }
}