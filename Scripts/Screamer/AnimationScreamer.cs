using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScreamer : Screamer
{
    public override void EndScream()
    {
        Destroy(gameObject);
    }
}