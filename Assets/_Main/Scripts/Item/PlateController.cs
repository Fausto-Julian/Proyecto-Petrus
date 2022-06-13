using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
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

            Debug.Log("ES KINEMATICO");
        }

        yield return new WaitForSeconds(1f);
        
        for (var i = 0; i < _food.Count; i++)
        {
            var body = _food[i].GetComponent<Rigidbody>();
            body.useGravity = true;
            body.isKinematic = false;

            Debug.Log("NO ES KINEMATICO");
        }
    }

    public void AddFood(GameObject food)
    {
        if (food.gameObject.CompareTag("Object"))
        {
            food.transform.SetParent(transform);
            var body = food.gameObject.GetComponent<Rigidbody>();
            body.useGravity = false;
            body.isKinematic = true;
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
        if (_food.Count == 0 || _food[0] == null)
        {
            Debug.Log("no hay comida");
            return false;
        }

        if (_orderTask.OrderMatters)
        {
            for (var i = 0; i < _orderTask.Ingredients.Count; i++)
            {
                if (_food[i].GetComponent<ObjectFood>().Id != _orderTask.Ingredients[i])
                {
                    return false;
                }
            }

            return true;
        }

        var completed = true;
        for (var j = 0; j < _food.Count; j++)
        {
            var idFood = _food[j].GetComponent<ObjectFood>().Id;
            if (completed)
            {
                
                for (var i = 0; i < _orderTask.Ingredients.Count; i++)
                {
                    Debug.Log(_orderTask.Ingredients[i]);
                    if (_orderTask.Ingredients[i] == idFood)
                    {
                        Debug.Log($"Es true: Id food: {idFood} = {_orderTask.Ingredients[i]}");
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

    public void ActivateViewTask()
    {
        HudManager.Instance.ActivateImageTask(_orderTask.ImageOrder);
    }
}