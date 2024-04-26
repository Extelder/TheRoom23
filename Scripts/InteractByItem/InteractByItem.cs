using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractByItem : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _save = true;
    [SerializeField] private Item _needItem;
    [SerializeField] private bool _spentItemWhenUsed = true;
    [SerializeField] private bool _destroyAfterUse = true;

    public UnityEvent ItemUsed;

    private void Awake()
    {
        if (_save)
            if (PlayerPrefs.GetInt("InteractByItem " + gameObject.name + _needItem, 0) == 1)
            {
                ItemUsed?.Invoke();
            }
    }

    public void Interact()
    {
        if (PlayerInventory.Instance.TryGetItem(_needItem))
        {
            ItemUsed?.Invoke();
            if (_spentItemWhenUsed)
                PlayerInventory.Instance.RemoveItem(_needItem);
            if (_save)
                PlayerPrefs.SetInt("InteractByItem " + gameObject.name + _needItem, 1);
            if (_destroyAfterUse)
                Destroy(this);
        }
    }
}