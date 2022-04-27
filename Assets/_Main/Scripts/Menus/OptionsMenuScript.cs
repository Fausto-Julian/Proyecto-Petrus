using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsMenuScript : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject optionsObject;
    // Update is called once per frame
    void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonHandler);

    }

    private void OnBackButtonHandler()
    {
        optionsObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }
}
