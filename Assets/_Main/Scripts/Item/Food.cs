using System;
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

    public string ID => id;
    
    public FoodType FoodType
    {
        get => foodType;
        set => foodType = value;
    }

    public StatusFood StatusFood
    {
        get => statusFood;
        set
        {
            switch (statusFood)
            {
                case StatusFood.Raw:
                {
                    if (value == StatusFood.Cooked || value == StatusFood.Burned)
                    {
                        statusFood = value;
                    }

                    break;
                }
                case StatusFood.Cooked:
                {
                    if (value == StatusFood.Burned)
                    {
                        statusFood = value;
                    }

                    break;
                }
                case StatusFood.Burned:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public Mesh CurrentMesh
    {
        get
        {
            return statusFood switch
            {
                StatusFood.Raw => meshFoodRaw,
                StatusFood.Cooked => meshFoodCooked,
                _ => meshFoodRaw
            };
        }
    }

    public MeshRenderer CurrentMeshRenderer
    {
        get
        {
            return statusFood switch
            {
                StatusFood.Raw => meshRendererFoodRaw,
                StatusFood.Cooked => meshRendererFoodCooked,
                _ => meshRendererFoodRaw
            };
        }
    }
}
