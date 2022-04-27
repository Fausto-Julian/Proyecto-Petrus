using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreditsMenuScript : MonoBehaviour
{
    [SerializeField] private Button backButton;

    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject creditsObject;
    // Update is called once per frame
    void Awake()
    {
        backButton.onClick.AddListener(OnBackButtonHandler);

    }

    private void OnBackButtonHandler()
    {
        creditsObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }
}
