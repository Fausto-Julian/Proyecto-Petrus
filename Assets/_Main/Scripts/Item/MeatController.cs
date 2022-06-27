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

public class MeatController : MonoBehaviour, ICuttable
{
    [SerializeField] private bool isCube;
    [SerializeField] private StatusFood statusFood;
    [SerializeField] private float timeCooking;
    [SerializeField] private GameObject meatRaw;
    [SerializeField] private GameObject meatCooked;
    [SerializeField] private GameObject meatBurned;
    [SerializeField] private GameObject cuttingPrefab;

    private AudioSource _source;

    [Header("Particles")]
    //[SerializeField] private ParticleSystem cockingParticle;  

    private bool _audioPlay;
    private float _cookingTimer;

    private bool _isCooking;

    private ObjectFood _objectFood;

    private void Start()
    {
        _objectFood = GetComponent<ObjectFood>();
        _source = GetComponent<AudioSource>();
        _audioPlay = true;
        _cookingTimer = timeCooking;
        switch (statusFood)
        {
            case StatusFood.Raw:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                if(isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else _objectFood.ChangeId(ObjectId.MeatRaw);
                break;
            case StatusFood.Cooked:
                meatRaw.SetActive(false);
                meatCooked.SetActive(true);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatCooked);
                }
                else _objectFood.ChangeId(ObjectId.MeatCooked);
                break;
            case StatusFood.Burned:
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                if (isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatBurned);
                }
                else _objectFood.ChangeId(ObjectId.MeatBurned);
                break;
            default:
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                meatBurned.SetActive(false);
                if (isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else _objectFood.ChangeId(ObjectId.MeatRaw);
                break;
        }
    }

    private void Update()
    {

        if (_isCooking)
        {
            _cookingTimer -= Time.deltaTime;

            if (_audioPlay && statusFood != StatusFood.Burned)
            {
                //_source.Play();
                _audioPlay = false;
            }

            if (_cookingTimer < 0)
            {
                ChangeStateMeat();
                _cookingTimer = timeCooking;
                _audioPlay = true;
            }
            //cockingParticle.Play();
        }
        else
        {
            //cockingParticle.Stop();
            _source.Stop();
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
                meatBurned.SetActive(false);
                if (isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatCooked);
                }
                else _objectFood.ChangeId(ObjectId.MeatCooked);
                break;
            case StatusFood.Cooked:
                statusFood = StatusFood.Burned;
                meatRaw.SetActive(false);
                meatCooked.SetActive(false);
                meatBurned.SetActive(true);
                if (isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatBurned);
                }
                else _objectFood.ChangeId(ObjectId.MeatBurned);
                break;
            case StatusFood.Burned:
                break;
            default:
                if (isCube)
                {
                    _objectFood.ChangeId(ObjectId.CubeMeatRaw);
                }
                else _objectFood.ChangeId(ObjectId.MeatRaw);
                statusFood = StatusFood.Raw;
                meatRaw.SetActive(true);
                meatCooked.SetActive(false);
                break;
        }
    }

    public void Cutting()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        Instantiate(cuttingPrefab, position, rotation);

        gameObject.SetActive(false);
    }
}
