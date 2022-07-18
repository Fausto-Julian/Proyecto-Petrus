using UnityEngine;

[CreateAssetMenu(fileName = "ProgressLevelsSo", menuName = "ProgressLevels", order = 0)]
public class ProgressLevelsSo : ScriptableObject
{

    [Header("Price Level 1")]
    [SerializeField] private float kitchenBellLevel1Price;
    [SerializeField] private float moreClientsLevel1Price;
    [SerializeField] private float kitchenSpeedLevel1Price;
    [SerializeField] private float sharpenKnifeLevel1Price;
    [SerializeField] private float basurinLevel1Price;
    [SerializeField] private float fortuneLevel1Price;

    [Header("Price Level 2")]
    [SerializeField] private float kitchenBellLevel2Price;
    [SerializeField] private float moreClientsLevel2Price;
    [SerializeField] private float kitchenSpeedLevel2Price;
    [SerializeField] private float sharpenKnifeLevel2Price;
    [SerializeField] private float basurinLevel2Price;
    [SerializeField] private float fortuneLevel2Price;

    [Header("Price Level 3")]
    [SerializeField] private float kitchenBellLevel3Price;
    [SerializeField] private float moreClientsLevel3Price;
    [SerializeField] private float kitchenSpeedLevel3Price;
    [SerializeField] private float sharpenKnifeLevel3Price;
    [SerializeField] private float basurinLevel3Price;
    [SerializeField] private float fortuneLevel3Price;

    [Header("Levels")]
    [SerializeField] public int KitchenBellLevel = 1;
    [SerializeField] public int MoreClientsLevel = 1;
    [SerializeField] public int KitchenSpeedLevel = 1;
    [SerializeField] public int SharpenKnifeLevel = 3;
    [SerializeField] public int BasurinLevel = 1;
    [SerializeField] public int FortuneLevel = 1;

    public float KitchenBellLevelPrice
    {
        get
        {
            return KitchenBellLevel switch
            {
                1 => kitchenBellLevel1Price,
                2 => kitchenBellLevel2Price,
                3 => kitchenBellLevel3Price,
                _ => kitchenBellLevel3Price
            };
        }
    }
    
    public float MoreClientsLevelPrice
    {
        get
        {
            return MoreClientsLevel switch
            {
                1 => moreClientsLevel1Price,
                2 => moreClientsLevel2Price,
                3 => moreClientsLevel3Price,
                _ => moreClientsLevel3Price
            };
        }
    }
    
    public float KitchenSpeedLevelPrice
    {
        get
        {
            return KitchenSpeedLevel switch
            {
                1 => kitchenSpeedLevel1Price,
                2 => kitchenSpeedLevel2Price,
                3 => kitchenSpeedLevel3Price,
                _ => kitchenSpeedLevel3Price
            };
        }
    }
    
    public float SharpenKnifeLevelPrice
    {
        get
        {
            return SharpenKnifeLevel switch
            {
                1 => sharpenKnifeLevel1Price,
                2 => sharpenKnifeLevel2Price,
                3 => sharpenKnifeLevel3Price,
                _ => sharpenKnifeLevel3Price
            };
        }
    }
    
    public float BasurinLevelPrice
    {
        get
        {
            return BasurinLevel switch
            {
                1 => basurinLevel1Price,
                2 => basurinLevel2Price,
                3 => basurinLevel3Price,
                _ => basurinLevel3Price
            };
        }
    }
    
    public float FortuneLevelPrice
    {
        get
        {
            return FortuneLevel switch
            {
                1 => fortuneLevel1Price,
                2 => fortuneLevel2Price,
                3 => fortuneLevel3Price,
                _ => fortuneLevel3Price
            };
        }
    }
}