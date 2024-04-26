using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAdviceUI : MonoBehaviour
{
    [SerializeField] private float _adviceDuration;
    [SerializeField] private TextMeshProUGUI _adviceTextComponent;

    public void ShowAdvice(string text)
    {
        StopAllCoroutines();
        StartCoroutine(Showing(text));
    }

    private IEnumerator Showing(string text)
    {
        _adviceTextComponent.text = text;

        yield return new WaitForSeconds(_adviceDuration);
        _adviceTextComponent.text = "";
    }
}