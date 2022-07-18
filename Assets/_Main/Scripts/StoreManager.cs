using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [Header("Reference Stats")] 
    [SerializeField] private ProgressLevelsSo progressLevelsSo;
    
    [Header("Reference Buttons level 1")]
    [SerializeField] private Button moreClientsLevelButton;
    [SerializeField] private Button kitchenSpeedLevelButton;
    [SerializeField] private Button sharpenKnifeLevelButton;
    [SerializeField] private Button basurinLevelButton;
    [SerializeField] private Button fortuneLevelButton;

    //private Button _kitchenBellLevelButton;
    private void Start()
    {
        //kitchenBellLevelButton.onClick.AddListener(LevelUpKitchenBellHandler);
        moreClientsLevelButton.onClick.AddListener(LevelUpMoreClientsHandler);
        kitchenSpeedLevelButton.onClick.AddListener(LevelUpKitchenSpeedHandler);
        sharpenKnifeLevelButton.onClick.AddListener(LevelUpSharpenKnifeHandler);
        basurinLevelButton.onClick.AddListener(LevelUpBasurinHandler);
        fortuneLevelButton.onClick.AddListener(LevelUpFortuneHandler);
    }
    
    /*
    private void LevelUpKitchenBellHandler()
    {
        if (GameManager.Instance.EnoughMoney(progressLevelsSo.KitchenBellLevelPrice))
        {
            GameManager.Instance.SubtractMoney(progressLevelsSo.KitchenBellLevelPrice);
            
            progressLevelsSo.KitchenBellLevel = progressLevelsSo.KitchenBellLevel switch
            {
                1 => 2,
                2 => 3,
                _ => progressLevelsSo.KitchenBellLevel
            };

            if (progressLevelsSo.KitchenBellLevel == 3)
                _kitchenBellLevelButton.interactable = false;
        }
    }*/
    
    private void LevelUpKitchenSpeedHandler()
    {
        if (GameManager.Instance.EnoughMoney(progressLevelsSo.KitchenSpeedLevelPrice))
        {
            GameManager.Instance.SubtractMoney(progressLevelsSo.KitchenSpeedLevelPrice);
            
            progressLevelsSo.KitchenSpeedLevel = progressLevelsSo.KitchenSpeedLevel switch
            {
                1 => 2,
                2 => 3,
                _ => progressLevelsSo.KitchenSpeedLevel
            };
            
            if (progressLevelsSo.KitchenSpeedLevel == 3)
                kitchenSpeedLevelButton.interactable = false;
        }
    }

    private void LevelUpMoreClientsHandler()
    {
        if (GameManager.Instance.EnoughMoney(progressLevelsSo.MoreClientsLevelPrice))
        {
            GameManager.Instance.SubtractMoney(progressLevelsSo.MoreClientsLevelPrice);
            
            progressLevelsSo.MoreClientsLevel = progressLevelsSo.MoreClientsLevel switch
            {
                1 => 2,
                2 => 3,
                _ => progressLevelsSo.MoreClientsLevel
            };
            
            if (progressLevelsSo.MoreClientsLevel == 3)
                moreClientsLevelButton.interactable = false;
        }
    }

    private void LevelUpSharpenKnifeHandler()
    {
        if (GameManager.Instance.EnoughMoney(progressLevelsSo.SharpenKnifeLevelPrice))
        {
            GameManager.Instance.SubtractMoney(progressLevelsSo.SharpenKnifeLevelPrice);
            
            progressLevelsSo.SharpenKnifeLevel = progressLevelsSo.SharpenKnifeLevel switch
            {
                2 => 1,
                3 => 2,
                _ => progressLevelsSo.SharpenKnifeLevel
            };
            
            if (progressLevelsSo.SharpenKnifeLevel == 1)
                sharpenKnifeLevelButton.interactable = false;
        }
    }

    private void LevelUpBasurinHandler()
    {
        if (GameManager.Instance.EnoughMoney(progressLevelsSo.BasurinLevelPrice))
        {
            GameManager.Instance.SubtractMoney(progressLevelsSo.BasurinLevelPrice);
            
            progressLevelsSo.BasurinLevel = progressLevelsSo.BasurinLevel switch
            {
                1 => 2,
                2 => 3,
                _ => progressLevelsSo.BasurinLevel
            };
            
            if (progressLevelsSo.BasurinLevel == 3)
                basurinLevelButton.interactable = false;
        }
    }

    private void LevelUpFortuneHandler()
    {
        if (GameManager.Instance.EnoughMoney(progressLevelsSo.FortuneLevelPrice))
        {
            GameManager.Instance.SubtractMoney(progressLevelsSo.FortuneLevelPrice);
            
            progressLevelsSo.FortuneLevel = progressLevelsSo.FortuneLevel switch
            {
                1 => 2,
                2 => 3,
                _ => progressLevelsSo.FortuneLevel
            };
            
            if (progressLevelsSo.FortuneLevel == 3)
                fortuneLevelButton.interactable = false;
        }
    }
}
