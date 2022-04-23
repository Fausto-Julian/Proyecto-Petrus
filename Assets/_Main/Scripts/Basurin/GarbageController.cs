using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GarbageController : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private GarbageFloor garbageFloor;
    
    private NavMeshAgent _navMeshAgent;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _navMeshAgent.destination = garbageFloor.objectDrops.Count > 0 ? garbageFloor.objectDrops[0].transform.position : startPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (garbageFloor.objectDrops.Count > 0)
        {
            if (other.gameObject == garbageFloor.objectDrops[0].gameObject)
            {
                garbageFloor.objectDrops.Remove(garbageFloor.objectDrops[0]);
                Destroy(other.gameObject);
            }  
        }
    }
}
