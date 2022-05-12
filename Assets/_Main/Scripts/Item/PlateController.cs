﻿
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour, IInteractable
{
    private OrderTaskSo _orderTask;
    private readonly List<GameObject> _food = new List<GameObject>();
    
    public Sprite GetSprite => _orderTask.ImageOrder;
    
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

    public void AddFood(GameObject food)
    {
        if (food.gameObject.CompareTag("Object"))
        {
            food.transform.SetParent(transform);
            _food.Add(food);
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

    public void ImportTask(OrderTaskSo orderTask)
    {
        _orderTask = orderTask;
    }

    public bool DeliverTask()
    {
        if (_food.Count > 1 || _food.Count == 0 || _food[0] == null)
        {
            Debug.Log("no hay comida");
            return false;
        }

        if (_orderTask.OrderMatters)
        {
            for (var i = 0; i < _orderTask.Ingredients.Count; i++)
            {
                if (_food[i].GetComponent<ObjectFood>().ID != _orderTask.Ingredients[i].ID)
                {
                    return false;
                }
            }

            return true;
        }

        var completed = true;
        for (var j = 0; j < _food.Count; j++)
        {
            var idFood = _food[j].GetComponent<ObjectFood>().ID;
            if (completed)
            {
                for (var i = 0; i < _orderTask.Ingredients.Count; i++)
                {
                    if (_orderTask.Ingredients[i].ID == idFood)
                    {
                        Debug.Log($"Es true: Id food: {idFood} = {_orderTask.Ingredients[i].ID}");
                        completed = true;
                        break;
                    }

                    completed = false;
                }
            }
            else
            {
                return false;
            }
        }

        return completed;
    }

    public void Interact()
    {
        TestHudOrderTask.Instance.ActiveImageTask(_orderTask.ImageOrder);
    }
}