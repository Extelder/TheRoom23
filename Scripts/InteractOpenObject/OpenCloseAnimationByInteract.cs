using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseAnimationByInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _openBoolName;

    private bool _opened;

    public void Interact()
    {
        if (_opened)
            SetOpenBoolFalse();
        else
            SetOpenBoolTrue();
    }

    public void SetOpenBoolTrue()
    {
        _animator.SetBool(_openBoolName, true);
        _opened = true;
    }

    public void SetOpenBoolFalse()
    {
        _animator.SetBool(_openBoolName, false);
        _opened = false;
    }
}