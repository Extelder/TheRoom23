using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory")]
public class Item : ScriptableObject
{
    public int Id;
    public string Name;
}