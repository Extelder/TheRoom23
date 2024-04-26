using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScene : MonoBehaviour
{
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioClip _music;
    [SerializeField] private AudioSource _bashka;
    [SerializeField] private AudioSource _telek;
    [SerializeField] private AudioSource _ohDamn;
    [SerializeField] private AudioSource _etoNeOn;
    [SerializeField] private AudioSource _kakaetoOshibka;

    [SerializeField] private Animator _animator;
    [SerializeField] private Door _door;
    [SerializeField] private GameObject _trash;
    [SerializeField] private GameObject _mainPlayer;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public void EnablePlayer()
    {
        _mainPlayer.SetActive(true);
        _camera.gameObject.SetActive(false);
    }

    public void DisablePlayer()
    {
        _mainMusic.volume = 0.6f;
        _mainPlayer.SetActive(false);
        _camera.gameObject.SetActive(true);
    }

    public void EndCatScene()
    {
        DisablePlayer();
        _animator.SetTrigger("End");
    }

    public void TakeTrash()
    {
        _trash.SetActive(false);
    }

    public void OpenDoor()
    {
        _door.TryOpenClose();
    }

    public void PlayStartSoundOhBashka()
    {
        _bashka.Play();
    }

    public void PlayStartSoundKtoVklychilTelek()
    {
        _telek.Play();
    }

    public void PlayerEndSoundWithOhDanm()
    {
        _ohDamn.Play();
    }

    public void PlayerEndSoundWithNavernoeEtoNeOn()
    {
        _etoNeOn.Play();
    }

    public void PlayerEndSoundWithKakaetoOshibka()
    {
        _kakaetoOshibka.Play();
    }

    public void Music()
    {
        _mainMusic.volume = 0.8f;
        _mainMusic.clip = _music;
        _mainMusic.Play();
    }
}