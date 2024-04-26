using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObjectWithUniqueNameSaveIfDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        if (PlayerPrefs.GetInt(_object.name, 0) == 1)
        {
            Destroy(_object);
        }
    }

    private void OnEnable()
    {
        _object.OnDestroyAsObservable().Subscribe(_ => { PlayerPrefs.SetInt(_object.name, 1); }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}