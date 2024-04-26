using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookableObject : MonoBehaviour, IInteractable
{
    [field: SerializeField] public Vector3 RotationObjectRotation { get; private set; }

    public UnityEvent StartLook;
    public UnityEvent StopLook;

    public void Interact()
    {
        PlayerObjectLooking.Instance.StartLook.AddListener((() =>
        {
            Debug.Log("StartLoocking");
            StartLook?.Invoke();
        }));
        PlayerObjectLooking.Instance.StopLook.AddListener((() =>
        {
            Debug.Log("StopLoocking");
            StopLook?.Invoke();
            PlayerObjectLooking.Instance.StartLook.RemoveAllListeners();
            PlayerObjectLooking.Instance.StopLook.RemoveAllListeners();
        }));
        PlayerObjectLooking.Instance.LookAtObject(this);
    }
}