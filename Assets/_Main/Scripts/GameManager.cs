
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private float startMoney;
    [SerializeField] private OrderTaskTable orderTaskTable;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem goodParticles;

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
        _currentMoneyDaily = 0;
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
    }
    
    public void SubtractMoney(float subtractMoney)
    {
        var newMoneyDaily = _currentMoneyDaily - subtractMoney;

        if (newMoneyDaily < -50)
        {
            GameOver();
        }
        else
        {
            _currentMoneyDaily -= subtractMoney;
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

    public void NextDay()
    {
        _money += _currentMoneyDaily;
        _currentMoneyDaily = 0;
        _totalOrdersDelivered = 0;
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("DefeatScene");
    }

    
    public void DeliverTask(GameObject plate)
    {
        var plateController = plate.GetComponent<PlateController>();
        
        if (plateController != null)
        {
            if (plateController.DeliverTask())
            {
                audioSource.Play();
                goodParticles.Play();

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

    public void ChangePlate(GameObject plate)
    {
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