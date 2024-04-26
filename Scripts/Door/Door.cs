using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private DoorAnimator _animator;
    [SerializeField] private bool _locked;
    [SerializeField] private bool _opened;


    private void Open()
    {
        _animator.SetOpenBoolTrue();
        _opened = true;
    }

    private void Close()
    {
        _animator.SetOpenBoolFalse();
        _opened = false;
    }

    public void TryOpenClose()
    {
        if (_opened)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void UnLock()
    {
        _locked = false;
    }

    public void Interact()
    {
        if (_locked == false)
        {
            TryOpenClose();
        }
    }
}