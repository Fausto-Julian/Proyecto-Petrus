using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusFood
{
    Raw,
    Cooked,
    Burned
}

public class MeatController : MonoBehaviour
{
    [SerializeField] private StatusFood statusFood;
    [SerializeField] private float timeCooking;
    [SerializeField] private GameObject meatRaw;
    [SerializeField] private GameObject meatCooked;
    [SerializeField] private GameObject meatBurned;

    private float _cookingTimer;

    private bool _isCooking;

    private void Start()
    {
        _cookingTimer = timeCooking;
        switch (statusFood)
        {
            case StatusFood.Raw:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                break;
            case StatusFood.Cooked:
                meatRaw.SetActive(false);
                meatCooked.SetActive(true);
                break;
            case StatusFood.Burned:
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                break;
            default:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                break;
        }
    }

    private void Update()
    {
        if (_isCooking)
        {
            _cookingTimer -= Time.deltaTime;

            if (_cookingTimer < 0)
            {
                ChangeStateMeat();
                _cookingTimer = timeCooking + 2.5f;
            }
        }
    }

    public void OnCooking()
    {
        _isCooking = true;
    }

    public void OffCooking()
    {
        _isCooking = false;
        _cookingTimer = timeCooking;
    }

    private void ChangeStateMeat()
    {
        switch (statusFood)
        {
            case StatusFood.Raw:
                statusFood = StatusFood.Cooked;
                meatRaw.SetActive(false);
                meatCooked.SetActive(true);
                break;
            case StatusFood.Cooked:
                statusFood = StatusFood.Burned;
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                break;
            case StatusFood.Burned:
                break;
            default:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                break;
        }
    }
}
