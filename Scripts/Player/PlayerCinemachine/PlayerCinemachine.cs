using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCinemachine : MonoBehaviour
{
    [SerializeField] private DataSettings _settings;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private CinemachineInputProvider _cinemachineInputProvider;

    private CinemachinePOV _cinemachinePOV;

    private void Awake()
    {
        _cinemachinePOV = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
    }

    private void OnEnable()
    {
        _settings.DataChanged += UpdateSensetivity;
    }

    private void OnDisable()
    {
        _settings.DataChanged -= UpdateSensetivity;
    }

    public void DisableRotation()
    {
        _cinemachineInputProvider.enabled = false;
    }

    public void EnableRotation()
    {
        _cinemachineInputProvider.enabled = true;
    }

    public void UpdateSensetivity()
    {
        _cinemachinePOV.m_VerticalAxis.m_MaxSpeed = _settings.LookSensetivity;
        _cinemachinePOV.m_HorizontalAxis.m_MaxSpeed = _settings.LookSensetivity;
    }
}