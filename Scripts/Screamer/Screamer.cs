using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Screamer : MonoBehaviour
{
    [SerializeField] private AudioSource _auidoSource;

    public virtual void Scream()
    {
        _auidoSource.Play();
    }

    public abstract void EndScream();
}