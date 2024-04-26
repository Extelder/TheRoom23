using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : RaycastBehaviour
{
    private void Update()
    {
        if (GetHitCollider(out Collider collider))
        {
            if (collider.TryGetComponent<LookOnScreamer>(out LookOnScreamer screamer))
            {
                screamer.Scream();
            }
        }
    }
}