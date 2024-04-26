using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCodButton : MonoBehaviour, IInteractable
{
    [SerializeField] private CodPanel _codPanel;

    public void Interact()
    {
        _codPanel.ResetCode();
    }
}