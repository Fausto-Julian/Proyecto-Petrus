
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    private List<GameObject> _food = new List<GameObject>();

    public IEnumerator StaticFood()
    {
        for (var i = 0; i < _food.Count; i++)
        {
            var body = _food[i].GetComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;
        }

        yield return new WaitForSeconds(1f);
        
        for (var i = 0; i < _food.Count; i++)
        {
            var body = _food[i].GetComponent<Rigidbody>();
            body.useGravity = true;
            body.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            other.transform.SetParent(transform);
            _food.Add(other.gameObject);
            var body = other.gameObject.GetComponent<Rigidbody>();
            body.useGravity = true;
            body.isKinematic = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            other.transform.SetParent(null);
            if (_food.Contains(other.gameObject))
            {
                _food.Remove(other.gameObject);
            }
        }
    }
}