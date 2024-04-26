using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodPanelButton : MonoBehaviour, IInteractable
{
    [SerializeField] private CodPanel _codPanel;
    [SerializeField] private int _number;

    public void Interact()
    {
        _codPanel.OnButtonPressed(_number);
    }
}