using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStop : MonoBehaviour
{
    [SerializeField] private PlayerCursor _cursor;
    [SerializeField] private PlayerPhysics _physics;
    [SerializeField] private PlayerCinemachine _cinemachine;

    public static PlayerStop Instance { get; private set; }

    public bool Stopped { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void Stop(bool disableCursor = true)
    {
        if (disableCursor)
            _cursor.Enable();
        _physics.Stopped = true;
        _cinemachine.DisableRotation();
        Stopped = true;
    }

    public void Play(bool enableCursor = true)
    {
        _physics.Stopped = false;
        if (enableCursor)
            _cursor.Disable();
        _cinemachine.EnableRotation();
        Stopped = false;
    }
}