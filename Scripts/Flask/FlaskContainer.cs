using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskContainer : MonoBehaviour
{
    [SerializeField] private Flask _flask;

    private void GetFlask()
    {
        PlayerInventory.Instance.AddItem(_flask.CurrentFlaskItem);
        _flask.gameObject.SetActive(false);
        _flask = null;
    }

    public void EnterFlask()
    {
        
    }
}