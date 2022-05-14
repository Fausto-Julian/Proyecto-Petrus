﻿using System.Collections.Generic;
using UnityEngine;

public class OrderTaskTable : MonoBehaviour
{
    [SerializeField] private int countMaxPlate;

    [Header("Reference"), Space]
    [SerializeField] private GameObject prefabPlate;
    [SerializeField] private List<Transform> spawnsPlates;

    private Plate[] _plates;
    private OrderTaskManager _orderTaskManager;

    private void Awake()
    {
        _plates = new Plate[countMaxPlate];

        for (var i = 0; i < _plates.Length; i++)
        {
            _plates[i] = new Plate();
            _plates[i].Transform = spawnsPlates[i];
        }
    }

    private void Start()
    {
        _orderTaskManager = GetComponent<OrderTaskManager>();

        AddTask();
    }

    public void AddTask()
    {
        for (var i = 0; i < _plates.Length; i++)
        {
            if (_plates[i].Item == null)
            {
                var task = _orderTaskManager.GetTaskRandom();
                _plates[i].Item =
                    Instantiate(prefabPlate, _plates[i].Transform.position, _plates[i].Transform.rotation);
                var plateController = _plates[i].Item.GetComponent<PlateController>();
                
                plateController.ImportTask(task);
            }
        }
    }

    public void RemoveTask(GameObject plate)
    {
        for (var i = 0; i < _plates.Length; i++)
        {
            if (_plates[i].Item == plate)
            {
                _plates[i].Item = null;
            }
        }
    }
}

class Plate
{
    public GameObject Item;
    public Transform Transform;
}