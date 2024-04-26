using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportations : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    public void Teleport(Transform point)
    {
        _characterController.enabled = false;
        transform.position = point.position;
        _characterController.enabled = true;
    }
}