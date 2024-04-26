using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image _loadingStatusImage;

    private AsyncOperation _asyncOperation;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        StartCoroutine(LoadindScene());
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    private IEnumerator LoadindScene()
    {
        yield return new WaitForSeconds(1f);
        _asyncOperation = SceneManager.LoadSceneAsync(1);

        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (!_asyncOperation.isDone)
            {
                float progress = _asyncOperation.progress / 0.9f;
                _loadingStatusImage.fillAmount = progress;
            }
        }).AddTo(_disposable);
    }
}