using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : RaycastBehaviour
{
    [SerializeField] private PlayerIndicator _indicator;

    private IInteractable _currentInteractable;

    private PlayerControls _controls;

    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.Interact.performed += _controls => TryInteract();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        if (GetHitCollider(out Collider collider))
        {
            if (collider.TryGetComponent<IInteractable>(out IInteractable IInteractable))
            {
                _currentInteractable = IInteractable;
                _indicator.Show();
                return;
            }
        }

        _indicator.Hide();
        _currentInteractable = null;
    }

    private void TryInteract()
    {
        _currentInteractable?.Interact();
    }
}