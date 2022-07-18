using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    private OrderTaskSo _orderTask;
    private readonly List<GameObject> _food = new List<GameObject>();
    
    public ClientState GetClientState => _orderTask.ClientState;

    private float _time;

    private IEnumerator StateLife()
    {
        _orderTask.ClientState = ClientState.Happy;
        yield return new WaitForSeconds(_orderTask.ClientTimer);
        
        _orderTask.ClientState = ClientState.Neutral;
        yield return new WaitForSeconds(_orderTask.ClientTimer);
        
        _orderTask.ClientState = ClientState.Angry;
        yield return new WaitForSeconds(_orderTask.ClientTimer);
        
        FindObjectOfType<GordonController>()?.PlaySound();
        GameManager.Instance.SubtractMoneyDaily(10);
        GameManager.Instance.ChangePlate(gameObject);
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
        _time = _orderTask.ClientTimer;
        StartCoroutine(nameof(StateLife));
    }

    public bool DeliverTask()
    {
        if (_food.Count == 0 || _food[0] == null)
        {
            FindObjectOfType<GordonController>()?.PlaySound();
            return false;
        }

        if (_orderTask.OrderMatters)
        {
            for (var i = 0; i < _orderTask.Ingredients.Count; i++)
            {
                if (_food[i].GetComponent<ObjectFood>().Id != _orderTask.Ingredients[i])
                {
                    FindObjectOfType<GordonController>()?.PlaySound();
                    return false;
                }
            }

            return true;
        }

        var completed = true;
        
        for (var i = 0; i < _orderTask.Ingredients.Count; i++)
        {
            if (completed)
            {
                for (var j = 0; j < _food.Count; j++)
                {
                    var idFood = _food[j].GetComponent<ObjectFood>().Id;

                    if (_orderTask.Ingredients[i] == idFood)
                    {
                        completed = true;
                        break;
                    }

                    completed = false;
                }
                
            }
            else
            {
                FindObjectOfType<GordonController>()?.PlaySound();
                return false;
            }
        }

        return completed;
    }

    public void ActivateViewTask()
    {
        HudManager.Instance.ActivateImageTask(_orderTask.ImageOrder, _orderTask.ImageClient);
    }

    public void RemoveObjectsInFloor()
    {
        FindObjectOfType<GarbageFloor>()?.RemoveObjectsDrops(_food);
    }
}