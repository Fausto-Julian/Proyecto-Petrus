using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum DifficultyTask
{
    Easy,
    Normal,
    Hard
}

[CreateAssetMenu(fileName = "TaskSO", menuName = "TaskSO", order = 0)]
public class OrderTaskSo : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private DifficultyTask difficultyTask;
    [SerializeField] private bool orderMatters;
    [SerializeField] private List<ObjectFood> ingredients = new List<ObjectFood>();
    [SerializeField] private Sprite imageOrder;

    public int Id => id;
    public DifficultyTask DifficultyTask => difficultyTask;
    public bool OrderMatters => orderMatters;
    public List<ObjectFood> Ingredients => ingredients;
    public Sprite ImageOrder => imageOrder;
}