using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerObjectRotation : MonoBehaviour
{
    [SerializeField] private Transform _object;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public void StartRotation()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            _object.Rotate(transform.right, Input.GetAxis("Mouse Y"), Space.World);
            _object.Rotate(transform.up, -Input.GetAxis("Mouse X"), Space.World);
        }).AddTo(_disposable);
    }

    public void StopRotation()
    {
        _object.localEulerAngles = new Vector3(0, 0, 0);
        _disposable.Clear();
    }
}