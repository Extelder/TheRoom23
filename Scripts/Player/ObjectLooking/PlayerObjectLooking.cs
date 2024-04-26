using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerObjectLooking : MonoBehaviour
{
    [SerializeField] private Transform _lookObjectParent;

    private PlayerControls _controls;
    private bool _looking;

    public UnityEvent StartLook;
    public UnityEvent StopLook;

    public static PlayerObjectLooking Instance { get; private set; }


    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    private void OnEnable()
    {
        _controls = new PlayerControls();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    public void LookAtObject(LookableObject gameObject)
    {
        if (_looking)
            return;
        _looking = true;
        StartLook?.Invoke();
        Debug.Log("Start");
        LookableObject spawnedObject =
            Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity, _lookObjectParent);
        spawnedObject.transform.localPosition = new Vector3(0, 0, 0);
        spawnedObject.transform.localEulerAngles = spawnedObject.RotationObjectRotation;
        _controls.Enable();
        _controls.Main.StopLookingOnObject.performed += context => StopLookingAtObject();
        PlayerStop.Instance.Stop(false);
    }

    public void StopLookingAtObject()
    {
        if (!_looking)
            return;
        _looking
            = false;
        Destroy(transform.GetChild(0).GetChild(0).gameObject);
        _controls.Main.StopLookingOnObject.performed -= context => StopLookingAtObject();
        _controls.Disable();
        StopLook?.Invoke();
        PlayerStop.Instance.Play(false);
    }
}