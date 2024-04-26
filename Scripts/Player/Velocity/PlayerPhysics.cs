using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerPhysics : MonoBehaviour
{
    private CharacterController _characterController;

    public Vector3 Velocity;

    public bool Stopped;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void LateUpdate()
    {
        if (!Stopped)
            _characterController.Move(Velocity * Time.deltaTime);
    }

    public bool IsGrounded() => _characterController.isGrounded;
}