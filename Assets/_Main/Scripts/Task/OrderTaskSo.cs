using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum DifficultyTask
{
    Easy,
    Normal,
    Hard
}

//[System.Serializable]
//public enum CustomerRace
//{
//    Human,
//    Minotaur,
//    Elf,
//    Ogre,
//    Basurin
//}

[CreateAssetMenu(fileName = "TaskSO", menuName = "TaskSO", order = 0)]
public class OrderTaskSo : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private DifficultyTask difficultyTask;
    [SerializeField] private bool orderMatters;
    [SerializeField] private List<ObjectId> ingredients = new List<ObjectId>();
    [SerializeField] private Sprite imageOrder;

    public int Id => id;
    public DifficultyTask DifficultyTask => difficultyTask;
    public bool OrderMatters => orderMatters;
    public List<ObjectId> Ingredients => ingredients;
    public Sprite ImageOrder => imageOrder;
}