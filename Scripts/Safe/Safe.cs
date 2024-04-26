using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : CodPanelValidInteractable
{
    [SerializeField] private SafeAnimator _animator;

    private bool _opened;

    public override void OnEntriedCodValid()
    {
        if (!_opened)
        {
            _animator.SetOpenBoolTrue();
            _opened = true;
        }
    }

    public override void OnEntriedCodNotValid()
    {
        if (_opened)
        {
            _animator.SetOpenBoolFalse();
            _opened = false;
        }
    }
}