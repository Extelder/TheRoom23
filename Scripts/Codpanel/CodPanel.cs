using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodPanel : MonoBehaviour
{
    [SerializeField] private string _notValidCodAdviceText;
    [SerializeField] private TextMeshProUGUI _entriedNumberTextComponent;
    [SerializeField] private int _validCod;
    [SerializeField] private CodPanelValidInteractable _interactable;

    public void OnButtonPressed(int buttonNumber)
    {
        if (_entriedNumberTextComponent.text.Length >= _validCod.ToString().Length)
        {
            ResetCode();
            _entriedNumberTextComponent.text += buttonNumber.ToString();
            return;
        }

        _entriedNumberTextComponent.text += buttonNumber.ToString();
    }

    public void CheckEntriedCodValid()
    {
        if (_entriedNumberTextComponent.text == _validCod.ToString())
        {
            CodValid();
            ResetCode();
        }
        else
        {
            CodNotValid();
            ResetCode();
        }
    }

    public void ResetCode()
    {
        _entriedNumberTextComponent.text = "";
    }

    private void CodValid()
    {
        _interactable.OnEntriedCodValid();
        Debug.Log("Entried Cod Valid");
    }

    private void CodNotValid()
    {
        _interactable.OnEntriedCodNotValid();
        PlayerAdvice.Instance.ShowAdvice(_notValidCodAdviceText);
        Debug.Log("Entried Cod Not Valid");
    }
}