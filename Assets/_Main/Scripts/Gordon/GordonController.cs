using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private float _currentTimeHide;
    private float _currentTimeShow;

    private bool _isShow;
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

                var distance = Vector3.Distance(transform.position, hideTransform.position);

                if (distance < 0.1f)
                {
                    _currentTimeShow = Random.Range(minTimerShow, maxTimerShow);
                    _isShow = false;
                }
            }
        }
        else
        {
            _currentTimeHide -= Time.deltaTime;

            if (_currentTimeHide <= 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, showTransform.position, 0.01f);

                var distance = Vector3.Distance(transform.position, showTransform.position);

                if (distance < 0.1f)
                {
                    OnShow.Invoke();
                    _currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
                    _isShow = true;
                }
            }
        }
    }

    public void FindFoodOnFloor(int count)
    {
        for (var i = 0; i < count; i++)
        {
            GameManager.Instance.SubtractMoney(2f);
        }

        PlaySound();

        Debug.Log("Encontre comida en el suelo, que no vuelva a PASAAAARR");
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }
    
}
