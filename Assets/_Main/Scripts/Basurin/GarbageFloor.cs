using System;
using System.Collections.Generic;
using UnityEngine;


public class GarbageFloor : MonoBehaviour
{
    public List<GameObject> objectDrops { get; private set; } = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            objectDrops.Add(other.gameObject);
        } 
    }
}