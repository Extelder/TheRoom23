using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineAnimator : DefaultAnimator
{
    [SerializeField] private string _crouchAnimatorBoolName;

    public void BeginCrouch()
    {
        SetAnimatorBoolAndDisableOthers(_crouchAnimatorBoolName, true);
    }

    public void StopCrouch()
    {
        SetAnimatorBoolAndDisableOthers(_crouchAnimatorBoolName, false);
    }

    public override void DisableAllAnimations()
    {
        SetAnimatorBool(_crouchAnimatorBoolName, false);
    }
}