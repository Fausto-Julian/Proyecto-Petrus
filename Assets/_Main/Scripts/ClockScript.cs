using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [SerializeField] private GameObject hourHand;
    [SerializeField] private GameObject minHand;
    [SerializeField] private GameObject secHand;

    private int _hourTime;
    private int _minTime;
    private int _secTime;
    private int _oldSecTime;
    private string _textTime;

    // Update is called once per frame
    void Update()
    {
        _hourTime = ClockManager.Instance.GetTimeInHour();
        _minTime = ClockManager.Instance.GetTimeInMinutes();
        _secTime = ClockManager.Instance.GetTimeInSeconds();
        _textTime = ClockManager.Instance.GetTimeText();

        
        updateClock();
        

        _oldSecTime = _secTime;
    }

    private void updateClock()
    {
        secHand.transform.rotation = Quaternion.Euler(0, 90,  _secTime * 6);
        Debug.Log("CAMBIO A: " + _secTime);
    }

}
