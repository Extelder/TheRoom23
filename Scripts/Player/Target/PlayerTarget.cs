using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTarget : MonoBehaviour
{
    [SerializeField] private string _startTargetRus;
    [SerializeField] private string _startTargetEng;
    [SerializeField] private DataSettings _settings;
    [SerializeField] private Text _text;

    private string _currentRusText;
    private string _currentEngText;
    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Start()
    {
        switch (_settings.SelectedLanguage.Value)
        {
            case Language.English:
                _text.text = _startTargetEng;
                break;
            case Language.Russian:
                _text.text = _startTargetRus;
                break;
        }

        _text.text = PlayerPrefs.GetString("Target", _text.text);

        _currentRusText = PlayerPrefs.GetString("Current Rus Target", _startTargetRus);
        _currentEngText = PlayerPrefs.GetString("Current Eng Target", _startTargetEng);

        _settings.SelectedLanguage.Subscribe(_ => { OnLanguageChanged(); }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
    }

    private void OnLanguageChanged()
    {
        switch (_settings.SelectedLanguage.Value)
        {
            case Language.English:
                _text.text = _currentEngText;
                break;
            case Language.Russian:
                _text.text = _currentRusText;
                break;
        }
    }

    public void ChangeTarget(string rus, string eng)
    {
        switch (_settings.SelectedLanguage.Value)
        {
            case Language.English:
                _text.text = eng;
                PlayerPrefs.SetString("Target", eng);
                break;
            case Language.Russian:
                _text.text = rus;
                PlayerPrefs.SetString("Target", rus);
                break;
        }

        _currentEngText = eng;
        _currentRusText = rus;

        PlayerPrefs.SetString("Current Rus Target", _currentRusText);
        PlayerPrefs.SetString("Current Eng Target", _currentEngText);
    }
}