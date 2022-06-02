using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;

    [SerializeField] private Image radialIndicatorBackGround;
    [SerializeField] private Image radialIndicator;
    [SerializeField] private Image imageTask;
    [SerializeField] private Image imagePickUp;
    [SerializeField] private Image imageInteract;

    private bool _isActiveRadial;
    private float _timerIndicator;
    private float _maxTime;

    private void Awake()
    {
        if (HudManager.Instance == null)
        {
            HudManager.Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        radialIndicatorBackGround.gameObject.SetActive(false);
        radialIndicator.gameObject.SetActive(false);
        imageTask.gameObject.SetActive(false);
        imagePickUp.gameObject.SetActive(false);
        imageInteract.gameObject.SetActive(false);

        _isActiveRadial = false;
    }

    private void Update()
    {
        if (_isActiveRadial)
        {
            radialIndicator.fillAmount = _timerIndicator / _maxTime;
            
            if (radialIndicator.fillAmount > 0.9f)
            {
                radialIndicatorBackGround.gameObject.SetActive(false);
                radialIndicator.gameObject.SetActive(false);
                _isActiveRadial = false;
            }
        }
    }

    public void ActiveImageRadial(float time, float maxTime)
    {
        radialIndicatorBackGround.gameObject.SetActive(true);
        radialIndicator.gameObject.SetActive(true);
        _isActiveRadial = true;
        _timerIndicator = time;
        _maxTime = maxTime;
    }

    public void ActivateImageTask(Sprite sprite)
    {
        imageTask.sprite = sprite;
        imageTask.gameObject.SetActive(true);
    }

    public void DeactivateImageTask()
    {
        imageTask.gameObject.SetActive(false);
    }
    
    public void ActivateImagePickUp()
    {
        imagePickUp.gameObject.SetActive(true);
    }

    public void DeactivateImagePickUp()
    {
        imagePickUp.gameObject.SetActive(false);
    }
    
    public void ActivateImageInteract()
    {
        imageInteract.gameObject.SetActive(true);
    }

    public void DeactivateImageInteract()
    {
        imageInteract.gameObject.SetActive(false);
    }
}