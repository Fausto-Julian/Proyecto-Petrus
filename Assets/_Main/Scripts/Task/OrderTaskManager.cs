using System.Collections.Generic;
using UnityEngine;

public class OrderTaskManager : MonoBehaviour
{
    [SerializeField] private List<OrderTaskSo> order = new List<OrderTaskSo>();

    public OrderTaskSo GetTaskRandom()
    {
        var index = Random.Range(0, order.Count);

        return order[index];
    }

    public OrderTaskSo GetTaskDifficulty(DifficultyTask difficulty)
    {
        var index = Random.Range(0, order.Count);

        while (order[index].DifficultyTask != difficulty)
        {
            index = Random.Range(0, order.Count);
        }

        return order[index];
    }
}