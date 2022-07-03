
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyManager : MonoBehaviour
{
    [SerializeField, Range(0, 24)] private int startHourDay;
    [SerializeField, Range(0, 24)] private int finishHourDay;

    [Header("Reference")] 
    [SerializeField] private GameObject finishDayPanel;
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private TextMeshProUGUI textTotalOrdersDelivered;
    [SerializeField] private TextMeshProUGUI textSavingsMoney;
    [SerializeField] private TextMeshProUGUI textTotalMoney;
    [SerializeField] private Button nextDayButton;

    private int _day = 1;

    private void Start()
    {
        ClockManager.Instance.SetTimeInHour(startHourDay);
        nextDayButton.onClick.AddListener(OnNextDayClicked);
        finishDayPanel.SetActive(false);
    }

    private void Update()
    {
        if (ClockManager.Instance.GetTimeInHour() >= finishHourDay)
        {
            var totalMoney = GameManager.Instance.GetMoney() + GameManager.Instance.GetMoneyDaily();
            if (totalMoney < 0)
            {
                GameManager.Instance.GameOver();
            }
            else
            {
                GameManager.Instance.SetPause(true);
                finishDayPanel.SetActive(true);
                ClockManager.Instance.SetTimeInHour(startHourDay);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;

                textMoney.text = GameManager.Instance.GetMoneyDaily().ToString();
                textTotalOrdersDelivered.text = GameManager.Instance.GetTotalOrdersDelivered().ToString();
                textSavingsMoney.text = GameManager.Instance.GetMoney().ToString();
                textTotalMoney.text = totalMoney.ToString();
            }
        }
    }

    private void OnNextDayClicked()
    {
        _day++;
        finishDayPanel.SetActive(false);
        GameManager.Instance.SetPause(false);
        GameManager.Instance.NextDay();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}