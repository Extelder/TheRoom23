using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField] private CinemachineAnimator _cinemachineAnimator;
    [SerializeField] private float _characterControllerCrouchHeight;
    [SerializeField] private Vector3 _characterControllerCrouchCenter;
    [SerializeField] private CharacterController _characterController;

    private PlayerControls _controls;

    private float _defaultCharacterControllerCrouchHeight;
    private Vector3 _defaultCharacterControllerCrouchCenter;

    private bool _crouch;

    private void Awake()
    {
        _defaultCharacterControllerCrouchCenter = _characterController.center;
        _defaultCharacterControllerCrouchHeight = _characterController.height;
    }

    private void OnEnable()
    {
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.Crouch.started += context => Begin();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    public void Begin()
    {
        _cinemachineAnimator.BeginCrouch();
    }

    public void Stop()
    {
        _cinemachineAnimator.StopCrouch();
    }

    public void SetCharacterControllerCrouchValues()
    {
        _crouch = true;

        _characterController.center = _characterControllerCrouchCenter;
        _characterController.height = _characterControllerCrouchHeight;
    }

    public void SetCharacterControllerDefaultValues()
    {
        _crouch = false;

        _characterController.center = _defaultCharacterControllerCrouchCenter;
        _characterController.height = _defaultCharacterControllerCrouchHeight;
    }

    public bool IsCrouching() => _crouch;
}