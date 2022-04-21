using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    Meat,
    Vegetables,
    Fruit
}

public enum StatusFood
{
    Cooked,
    Raw,
    Burned
}

[CreateAssetMenu(fileName = "Food", menuName = "Food", order = 0)]
public class Food : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private FoodType foodType;
    [SerializeField] private StatusFood statusFood;
    [SerializeField] private Mesh meshFoodRaw;
    [SerializeField] private MeshRenderer meshRendererFoodRaw;
    [SerializeField] private Mesh meshFoodCooked;
    [SerializeField] private MeshRenderer meshRendererFoodCooked;
    [SerializeField] private Mesh meshFoodBurned;
    [SerializeField] private MeshRenderer meshRendererFoodBurned;

    public string ID { get { return id; } }
    public FoodType FoodType
    {
        get
        {
            return foodType;
        }
        set
        {
            foodType = value;
        }
    }

    public StatusFood StatusFood
    {
        get
        {
            return statusFood;
        }
        set
        {
            if (statusFood == StatusFood.Raw)
            {
                if (value == StatusFood.Cooked || value == StatusFood.Burned)
                {
                    statusFood = value;
                }
            }
            else if (statusFood == StatusFood.Cooked)
            {
                if (value == StatusFood.Burned)
                {
                    statusFood = value;
                }
            }
        }
    }

    public Mesh CurrentMesh
    {
        get
        {
            if (statusFood == StatusFood.Raw)
            {
                return meshFoodRaw;
            }
            else if (statusFood == StatusFood.Cooked)
            {
                return meshFoodCooked;
            }
            return meshFoodRaw;
        }
    }

    public MeshRenderer CurrentMeshRenderer
    {
        get
        {
            if (statusFood == StatusFood.Raw)
            {
                return meshRendererFoodRaw;
            }
            else if (statusFood == StatusFood.Cooked)
            {
                return meshRendererFoodCooked;
            }
            return meshRendererFoodRaw;
        }
    }
}
