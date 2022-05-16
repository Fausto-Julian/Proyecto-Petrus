using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadController : MonoBehaviour
{
    [SerializeField] private StatusFood statusFood;
    [SerializeField] private float timeCooking;
    [SerializeField] private GameObject breadRaw;
    [SerializeField] private GameObject breadToasted;
    [SerializeField] private GameObject breadBurned;

    private float _cookingTimer;

    private bool _isCooking;

    private ObjectFood _objectFood;

    private void Start()
    {
        _objectFood = GetComponent<ObjectFood>();
        
        _cookingTimer = timeCooking;
        switch (statusFood)
        {
            case StatusFood.Raw:
                breadRaw.SetActive(true);
                breadToasted.SetActive(false);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadRaw);
                break;
            case StatusFood.Cooked:
                breadRaw.SetActive(false);
                breadToasted.SetActive(true);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadToasted);
                break;
            case StatusFood.Burned:
                breadRaw.SetActive(false);
                breadToasted.SetActive(false);
                breadBurned.SetActive(true);
                _objectFood.ChangeId(ObjectId.BreadBurner);
                break;
            default:
                breadRaw.SetActive(true);
                breadToasted.SetActive(false);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadRaw);
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
                breadRaw.SetActive(false);
                breadToasted.SetActive(true);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadToasted);
                break;
            case StatusFood.Cooked:
                statusFood = StatusFood.Burned;
                breadRaw.SetActive(false);
                breadToasted.SetActive(false);
                breadBurned.SetActive(true);
                _objectFood.ChangeId(ObjectId.BreadBurner);
                break;
            case StatusFood.Burned:
                break;
            default:
                breadRaw.SetActive(true);
                breadToasted.SetActive(false);
                breadBurned.SetActive(false);
                _objectFood.ChangeId(ObjectId.BreadRaw);
                break;
        }
    }
}
