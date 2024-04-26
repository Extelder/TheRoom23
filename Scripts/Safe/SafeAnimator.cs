using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SafeAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string _openBoolName = "IsOpened";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetOpenBoolTrue()
    {
        _animator.SetBool(_openBoolName, true);
    }

    public void SetOpenBoolFalse()
    {
        _animator.SetBool(_openBoolName, false);
    }
}