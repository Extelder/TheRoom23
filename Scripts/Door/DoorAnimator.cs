using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _openBoolName;

    public void SetOpenBoolTrue()
    {
        _animator.SetBool(_openBoolName, true);
    }

    public void SetOpenBoolFalse()
    {
        _animator.SetBool(_openBoolName, false);
    }
}