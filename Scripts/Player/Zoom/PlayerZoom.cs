using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UniRx;
using UnityEngine;

public class PlayerZoom : MonoBehaviour
{
    [SerializeField] private float _zoomFov;
    [SerializeField] private float _zoomDuration;
    [SerializeField] private CinemachineVirtualCamera _cinemachine;

    private float _defaultFov;
    private PlayerControls _controls;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnEnable()
    {
        _defaultFov = _cinemachine.m_Lens.FieldOfView;
        _controls = new PlayerControls();
        _controls.Enable();
        _controls.Main.Zoom.started += context => BeginZoom();
        _controls.Main.Zoom.canceled += context => StopZoom();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void BeginZoom()
    {
        _disposable.Clear();
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (_cinemachine.m_Lens.FieldOfView == _zoomFov)
            {
                _disposable.Clear();
                return;
            }

            _cinemachine.m_Lens.FieldOfView = Mathf.Lerp(_cinemachine.m_Lens.FieldOfView, _zoomFov, _zoomDuration);
        }).AddTo(_disposable);
    }

    private void StopZoom()
    {
        _disposable.Clear();
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (_cinemachine.m_Lens.FieldOfView == _defaultFov)
            {
                _disposable.Clear();
                return;
            }

            _cinemachine.m_Lens.FieldOfView = Mathf.Lerp(_cinemachine.m_Lens.FieldOfView, _defaultFov, _zoomDuration);
        }).AddTo(_disposable);
    }
}