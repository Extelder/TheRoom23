using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCodValidButton : MonoBehaviour, IInteractable
{
    [SerializeField] private CodPanel _codPanel;

    public void Interact()
    {
        _codPanel.CheckEntriedCodValid();
    }
}