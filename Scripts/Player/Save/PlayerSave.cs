using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSave : MonoBehaviour
{
    [SerializeField] private PlayerCrouchCheckRoof _crouchCheckRoof;
    [SerializeField] private InventoryData _inventoryData;

    private bool _reset = false;

    private void Awake()
    {
        GetComponent<CharacterController>().enabled = false;
        Vector3 lastPosition;

        Debug.Log("Load");
        lastPosition.x = PlayerPrefs.GetFloat("Transform Position X", transform.position.x);
        lastPosition.y = PlayerPrefs.GetFloat("Transform Position Y", transform.position.y);
        lastPosition.z = PlayerPrefs.GetFloat("Transform Position Z", transform.position.z);
        transform.position = lastPosition;

        GetComponent<CharacterController>().enabled = true;
    }

    private void Update()
    {
        Save();
    }


    public void Save()
    {
        if (!_reset && _crouchCheckRoof.СanStandUp)
        {
            PlayerPrefs.SetFloat("Transform Position X", transform.position.x);
            PlayerPrefs.SetFloat("Transform Position Y", transform.position.y);
            PlayerPrefs.SetFloat("Transform Position Z", transform.position.z);
            PlayerPrefs.Save();
        }
    }

    public void DeleteAllPrefs()
    {
        _reset = true;
        PlayerPrefs.DeleteAll();
        _inventoryData.ResetItems();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}