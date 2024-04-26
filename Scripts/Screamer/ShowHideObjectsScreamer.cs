using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObjectsScreamer : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;

    public void Show()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].SetActive(true);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].SetActive(false);
        }
    }
}