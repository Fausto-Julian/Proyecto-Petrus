
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private float startMoney;
    [SerializeField] private OrderTaskTable orderTaskTable;

    private float _currentMoney;

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
        _currentMoney = startMoney;
    }

    public void AddMoney(float money)
    {
        if (money < 0)
        {
            money = 0;
        }

        _currentMoney += money;
    }

    public void SubtractMoney(float subtractMoney)
    {
        if (_currentMoney - subtractMoney < 0)
        {
            _currentMoney = 0;
        }
        else
        {
            _currentMoney -= subtractMoney;
        }
    }

    public float GetMoney()
    {
        return _currentMoney;
    }

    public void DeliverTask(GameObject plate)
    {
        var plateController = plate.GetComponent<PlateController>();

        if (plateController != null)
        {
            if (plateController.DeliverTask())
            {
                AddMoney(20);
                Debug.Log("Tarea Hecha correctamente!! Felicitaciones! se le agrego $20 a su cuenta");
            }
            else
            {
                SubtractMoney(10);
                Debug.Log("No es lo que pidio el cliente, otra mas asi y te despido. Te quito $20 de tu cuenta");
            }
        }

        
        orderTaskTable.RemoveTask(plate);
        Destroy(plate);
        orderTaskTable.AddTask();
    }
    
}