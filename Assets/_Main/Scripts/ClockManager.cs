
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public static ClockManager Instance;

    [SerializeField] private float startTimeSeconds;
    [SerializeField, Range(-10f, 10f)] private float scaleTime = 1;

    private float _scaleDefault;
    private float _time;
    private string _timeText;

    private int _hour;
    private int _minutes;
    private int _seconds;

    private void Awake()
    {
        if (ClockManager.Instance == null)
        {
            ClockManager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _scaleDefault = scaleTime;
        _time = startTimeSeconds;
        
        UpdateClock();
    }

    private void Update()
    {
        _time += Time.deltaTime * scaleTime;

        UpdateClock();
    }

    private void UpdateClock()
    {
        if (_time < 0) _time = 0;
        
        _minutes = (int)_time / 60;
        
        _hour = _minutes / 60;
        _minutes %= 60;
        
        _seconds = (int)_time % 60;


        _timeText = $"{_hour}:{_minutes}:{_seconds}";
    }

    public void ResetDefaultScale()
    {
        scaleTime = _scaleDefault;
    }

    public void SetScaleTime(float scale)
    {
        scale = Mathf.Clamp(scale, -10f, 10f);
        scaleTime = scale;
    }

    public void AddScaleTime(float addScale)
    {
        scaleTime += addScale;
        scaleTime = Mathf.Clamp(scaleTime, -10f, 10f);
    }
    
    public void RemoveScaleTime(float removeScale)
    {
        scaleTime -= removeScale;
        scaleTime = Mathf.Clamp(scaleTime, -10f, 10f);
    }

    public int GetTimeInSeconds()
    {
        return _seconds;
    }
    
    public int GetTimeInMinutes()
    {
        return _minutes;
    }
    
    public int GetTimeInHour()
    {
        return _hour;
    }

    public string GetTimeText()
    {
        return _timeText;
    }
}