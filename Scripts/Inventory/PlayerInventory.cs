using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InventoryData _data;

    public static PlayerInventory Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void AddItem(PickupItem item)
    {
        _data.Items.Add(item.CurrentItem);
    }

    public void AddItem(Item item)
    {
        _data.Items.Add(item);
    }

    public bool TryGetItem(Item item)
    {
        foreach (var itemInList in _data.Items)
        {
            if (itemInList == item)
            {
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(Item item)
    {
        _data.ItemRemoved(item);
        _data.Items.Remove(item);
    }
}