using System;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public Action OnShow;

    private void Awake()
    {
        _currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
        _currentTimeShow = Random.Range(minTimerShow, maxTimerShow);

        _isShow = false;

        transform.position = hideTransform.position;
    }

    private void Update()
    {
        if (!_isShow)
        {
            _currentTimeHide -= Time.deltaTime;

            if (_currentTimeHide <= 0)
            {
                _currentTimeHide = Random.Range(minTimerHide, maxTimerHide);
                _isShow = true;
                OnShow.Invoke();
                transform.position = showTransform.position;
            }
        }

        if (_isShow)
        {
            _currentTimeShow -= Time.deltaTime;

            if (_currentTimeShow <= 0)
            {
                _currentTimeShow = Random.Range(minTimerShow, maxTimerShow);

                _isShow = false;
                transform.position = hideTransform.position;
            }
        }
    }

    public void FindFoodOnFloor(int count)
    {
        for (var i = 0; i < count; i++)
        {
            GameManager.Instance.SubtractMoney(2f);
        }

        Debug.Log("Encontre comida en el suelo, que no vuelva a PASAAAARR");
    }
    
}
