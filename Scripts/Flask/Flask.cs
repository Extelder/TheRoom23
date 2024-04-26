using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlaskColor
{
    Red,
    Green,
    Blue
}
public class Flask : MonoBehaviour
{
    public FlaskColor Color; 
    public Item CurrentFlaskItem;
}