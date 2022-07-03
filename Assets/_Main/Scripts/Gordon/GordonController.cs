using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class GordonController : MonoBehaviour
{
    [SerializeField] private float minTimerHide;
    [SerializeField] private float maxTimerHide;
    [SerializeField] private float minTimerShow;
    [SerializeField] private float maxTimerShow;
    [SerializeField] private Transform hideTransform;
    [SerializeField] private Transform showTransform;
    [SerializeField] private AudioClip errorSound; 
    [SerializeField] private AudioClip stepsSound; 

    private float _currentTimeHide;
    private float _currentTimeShow;

    private bool _isShow;
    private bool _isPlayingAudio;
    private bool _isPlayingAudioAux;
    private bool _eventActive;

    private AudioSource _audioSource;

    public event Action OnShow;

    private void Awake()
    {
        _currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
        _currentTimeShow = Random.Range(minTimerShow, maxTimerShow);

        _isShow = false;

        transform.position = hideTransform.position;

        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isShow)
        {
            _currentTimeShow -= Time.deltaTime;

            if (_currentTimeShow <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, hideTransform.position, 0.01f);


                if (!_isPlayingAudio)
                {
                    _isPlayingAudioAux = true;
                    _isPlayingAudio = true;
                }

                var distance = Vector3.Distance(transform.position, hideTransform.position);

                if (distance < 0.1f)
                {
                    _currentTimeShow = Random.Range(minTimerShow, maxTimerShow);
                    _isShow = false;
                    _isPlayingAudio = false;
                    _audioSource.Stop();
                }
            }
        }
        else
        {
            _currentTimeHide -= Time.deltaTime;

            if (_currentTimeHide <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, showTransform.position, 0.01f);

                if (!_isPlayingAudio)
                {
                    _isPlayingAudioAux = true;
                    _isPlayingAudio = true;
                }

                var distance = Vector3.Distance(transform.position, showTransform.position);

                if (distance < 0.1f)
                {
                    OnShow.Invoke();
                    _currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
                    _isShow = true;

                    _isPlayingAudio = false;
                    _audioSource.Stop();
                }
            }
        }


        if(_isPlayingAudio)
        {
            if(_isPlayingAudioAux)
            {
                _audioSource.PlayOneShot(stepsSound);
                _isPlayingAudioAux = false;
            }
        }
    }

    //Te lo cambio para que pase la lista entera en vez de un INT para asi poder eliminar los objetos que encuentre
    public void FindFoodOnFloor(int count)
    {
        for (var i = 0; i < count; i++)
        {
            GameManager.Instance.SubtractMoney(2f);
        }

        PlayErrorSound();
    }

    public void PlayErrorSound()
    {
        //_audioSource.Play();
        _audioSource.PlayOneShot(errorSound);
    }

    public void PlayStepsSound()
    {
        _audioSource.PlayOneShot(stepsSound);
    }
}
