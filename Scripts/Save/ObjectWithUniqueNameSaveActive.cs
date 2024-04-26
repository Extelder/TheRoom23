using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObjectWithUniqueNameSaveActive : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private bool _valueToTrigger;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _object.SetActive(Convert.ToBoolean(PlayerPrefs.GetInt(_object.name, Convert.ToInt16(_object.activeSelf))));
    }

    private void OnEnable()
    {
        if (_valueToTrigger == true)
        {
            _object.OnEnableAsObservable().Subscribe(_ =>
            {
                Debug.Log("Enable");
                PlayerPrefs.SetInt(_object.name, 1);
            }).AddTo(_disposable);
        }
        else
        {
            _object.OnDisableAsObservable().Subscribe(_ =>
            {
                Debug.Log("Disable");
                PlayerPrefs.SetInt(_object.name, 0);
            }).AddTo(_disposable);
        }
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }
}