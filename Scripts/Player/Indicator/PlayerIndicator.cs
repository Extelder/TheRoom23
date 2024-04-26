using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _indicator;

    public void Show()
    {
        _indicator.SetActive(true);
    }

    public void Hide()
    {
        _indicator.SetActive(false);
    }
}