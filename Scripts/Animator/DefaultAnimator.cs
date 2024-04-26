using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultAnimator : MonoBehaviour
{
    public Animator Animator;

    public abstract void DisableAllAnimations();

    public void SetAnimatorBoolAndDisableOthers(string boolName, bool value)
    {
        DisableAllAnimations();
        Animator.SetBool(boolName, value);
    }

    public void SetAnimatorBool(string boolName, bool value)
    {
        Animator.SetBool(boolName, value);
    }
}