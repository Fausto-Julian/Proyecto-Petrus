
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private float startMoney;
    [SerializeField] private OrderTaskTable orderTaskTable;
    [SerializeField] private AudioSource audioSource;

    private float _money;
    private float _totalOrdersDelivered;
    private float _currentMoneyDaily;
    private bool _pause;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _totalOrdersDelivered = 0;
        _currentMoneyDaily = startMoney;
        _money = startMoney;

        audioSource = GetComponent<AudioSource>();
    }

    public void AddMoney(float money)
    {
        if (money < 0)
        {
            money = 0;
        }

        _currentMoneyDaily += money;
        _money += money;
    }
    
    public void SubtractMoney(float subtractMoney)
    {
        var newMoneyDaily = _currentMoneyDaily - subtractMoney;
        var newMoney = _money - subtractMoney;
        
        if (newMoneyDaily < 0)
        {
            if (newMoney < 0)
            {
                _money = 0;
            }
            else
            {
                _money -= subtractMoney;
            }
            _currentMoneyDaily = 0;
        }
        else
        {
            _currentMoneyDaily = newMoneyDaily;
            _money = newMoney;
        }
    }

    public float GetMoney()
    {
        return _money;
    }
    
    public float GetMoneyDaily()
    {
        return _currentMoneyDaily;
    }

    public float GetTotalOrdersDelivered()
    {
        return _totalOrdersDelivered;
    }

    public void ResetDay()
    {
        _currentMoneyDaily = 0;
    }

    public void DeliverTask(GameObject plate)
    {
        var plateController = plate.GetComponent<PlateController>();
        
        if (plateController != null)
        {
            if (plateController.DeliverTask())
            {
                audioSource.Play();

                switch (plateController.GetClientState)
                {
                    case ClientState.Happy:
                        AddMoney(20);
                        break;
                    case ClientState.Neutral:
                        AddMoney(10);
                        break;
                    case ClientState.Angry:
                        AddMoney(5);
                        break;
                    default:
                        AddMoney(20);
                        break;
                }
                _totalOrdersDelivered++;
            }
            else
            {
                SubtractMoney(10);
            }
        }

        orderTaskTable.RemoveTask(plate);
        Destroy(plate);
        orderTaskTable.AddTask();
    }

    public void SetPause(bool isPause)
    {
        _pause = isPause;
    }

    public bool GetPause()
    {
        return _pause;
    }
}