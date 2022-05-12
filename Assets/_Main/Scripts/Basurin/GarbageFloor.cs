using System;
using System.Collections.Generic;
using UnityEngine;


public class GarbageFloor : MonoBehaviour
{
    [SerializeField] private GordonController gordonController;
    
    public List<GameObject> ObjectDrops { get; } = new List<GameObject>();

    private void Start()
    {
        gordonController.OnShow += OnShowHandler;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            ObjectDrops.Add(other.gameObject);
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (ObjectDrops.Contains(other.gameObject))
        {
            ObjectDrops.Remove(other.gameObject);
        }
    }

    private void OnShowHandler()
    {
        if (ObjectDrops.Count > 0)
        {
            gordonController.FindFoodOnFloor(ObjectDrops.Count);
        }
    }
}