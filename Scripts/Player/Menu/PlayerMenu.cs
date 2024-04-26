using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private DataSettings _dataSettings;
    [SerializeField] private GameObject _canvas;

    private PlayerControls _controls;

    private bool _opened;

    private bool _beStopped;

    private void OnEnable()
    {
        _dataSettings.Load();
        _controls = new PlayerControls();
        _controls.Enable();

    }

    private void OnDisable()
    {
        _dataSettings.Save();
        _controls.Disable();
    }

    private void OpenClose()
    {
        if (_opened)
            Close();
        else
            Open();
    }

    public void Open()
    {
        _opened = true;
        _canvas.SetActive(true);
        if (PlayerStop.Instance.Stopped)
        {
            _beStopped = true;
        }

        if (!PlayerStop.Instance.Stopped)
            PlayerStop.Instance.Stop();
    }

    public void Close()
    {
        _opened = false;
        _canvas.SetActive(false);
        if (!_beStopped)
            PlayerStop.Instance.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}