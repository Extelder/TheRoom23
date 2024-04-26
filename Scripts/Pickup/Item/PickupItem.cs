using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IPickuptable
{
    public Item CurrentItem;

    public void Pickup()
    {
        PlayerInventory.Instance.AddItem(this);
        Destroy(gameObject);
    }
}