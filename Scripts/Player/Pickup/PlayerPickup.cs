using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : RaycastBehaviour
{
    [SerializeField] private PlayerIndicator _indicator;

    private IPickuptable _currentPickupItem;

    private PlayerControls _controls;

    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.Pickup.performed += _controls => TryPickup();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        if (GetHitCollider(out Collider collider))
        {
            if (collider.TryGetComponent<IPickuptable>(out IPickuptable pickup))
            {
                _currentPickupItem = pickup;
                _indicator.Show();
                return;
            }
        }

        _indicator.Hide();
        _currentPickupItem = null;
    }

    private void TryPickup()
    {
        _currentPickupItem?.Pickup();
    }
}