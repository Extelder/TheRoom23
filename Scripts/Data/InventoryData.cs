using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", order = 0, menuName = "Data/Inventory")]
public class InventoryData : ScriptableObject
{
    public List<Item> Items;
    public List<Item> ItemsPrefabs;

    public void Awake()
    {
        Load();
    }

    private void OnDisable()
    {
        Save();
    }

    private void Save()
    {
        foreach (var item in Items)
        {
            PlayerPrefs.SetInt(item.ToString(), 1);
        }
    }
    
    public void ResetItems()
    {
       Items.Clear();
    }

    public void ItemRemoved(Item item)
    {
        PlayerPrefs.SetInt(item.ToString(), 0);
    }

    private void Load()
    {
        Items.Clear();
        foreach (var itemsPrefab in ItemsPrefabs)
        {
            if (PlayerPrefs.GetInt(itemsPrefab.ToString(), 0) == 1)
            {
                Items.Add(itemsPrefab);
            }
        }
    }
}