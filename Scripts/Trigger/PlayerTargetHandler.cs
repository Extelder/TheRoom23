using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetHandler : MonoBehaviour
{
    [SerializeField] private string _rusText;
    [SerializeField] private string _engText;
    [SerializeField] private PlayerTarget _target;

    private bool _triggered;

    public void SendTargetString()
    {
        if (_triggered == false)
        {
            _target.ChangeTarget(_rusText, _engText);
            _triggered = true;
        }
    }
}