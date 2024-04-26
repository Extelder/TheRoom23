using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchCheckRoof : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private PlayerCrouch _crouch;

    private PlayerControls _controls;

    private bool _buttonPressed;

    public bool СanStandUp { get; private set; }

    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();

        _controls.Main.Crouch.started += context => { _buttonPressed = true; };
        _controls.Main.Crouch.canceled += context => { _buttonPressed = false; };
    }

    private void OnDisable()
    {
        _controls.Enable();
    }

    private void Update()
    {
        CheckVentilation(transform.position, _checkRadius);
        TryStandUp();
    }

    private void CheckVentilation(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<VentrilationTrigger>(out VentrilationTrigger ventrilationTrigger))
            {
                СanStandUp = false;
                return;
            }
        }

        СanStandUp = true;
    }

    public void TryStandUp()
    {
        if (_buttonPressed == false && СanStandUp == true && _crouch.IsCrouching())
        {
            _crouch.Stop();
        }
    }
}