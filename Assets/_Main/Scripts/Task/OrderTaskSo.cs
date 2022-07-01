using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum DifficultyTask
{
    Easy,
    Normal,
    Hard
}

[System.Serializable]
public enum ClientState
{
    Happy,
    Neutral,
    Angry
}


[CreateAssetMenu(fileName = "TaskSO", menuName = "TaskSO", order = 0)]
public class OrderTaskSo : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private DifficultyTask difficultyTask;
    [SerializeField] private bool orderMatters;
    [SerializeField] private List<ObjectId> ingredients = new List<ObjectId>();
    [SerializeField] private Sprite imageOrder;

    [Header("Client")]
    [SerializeField] private float clientTimer;
    [SerializeField] private ClientState clientState;
    [SerializeField] private Sprite imageClientHappy;
    [SerializeField] private Sprite imageClientNeutral;
    [SerializeField] private Sprite imageClientAngry;
    

    public int Id => id;
    public DifficultyTask DifficultyTask => difficultyTask;
    public bool OrderMatters => orderMatters;

    public List<ObjectId> Ingredients => ingredients;

    public float ClientTimer => clientTimer;
    public ClientState ClientState 
    {
        get => clientState;
        set {clientState = value;}
    } 
    public Sprite ImageOrder => imageOrder;
    public Sprite ImageClient
    {
        get
        {
            switch (clientState)
            {
                case ClientState.Happy:
                    return imageClientHappy;
                case ClientState.Neutral:
                    return imageClientNeutral;
                case ClientState.Angry:
                    return imageClientAngry;
                default:
                    return imageClientHappy;
            }
        }
    }
}