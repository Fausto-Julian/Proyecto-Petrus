using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialMenuScript : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject tutorialObject;
    // Update is called once per frame
    void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonHandler);

    }

    private void OnBackButtonHandler()
    {
        tutorialObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }
}
