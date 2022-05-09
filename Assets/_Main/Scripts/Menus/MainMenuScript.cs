using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject mainMenuObject;
    [SerializeField] private GameObject optionsObject;
    [SerializeField] private GameObject tutorialObject;
    [SerializeField] private GameObject creditsObject;
    [SerializeField] private string nextScene;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonHandler);
        optionsButton.onClick.AddListener(OnOptionsButtonHandler);
        tutorialButton.onClick.AddListener(OnTutorialButtonHandler);
        creditsButton.onClick.AddListener(OnCreditsButtonHandler);
        exitButton.onClick.AddListener(OnExitButtonHandler);

        mainMenuObject.SetActive(true);
        optionsObject.SetActive(false);
        tutorialObject.SetActive(false);
        creditsObject.SetActive(false);
    }

    private void OnPlayButtonHandler()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnOptionsButtonHandler()
    {
        mainMenuObject.SetActive(false);
        optionsObject.SetActive(true);
    }

    private void OnTutorialButtonHandler()
    {
        mainMenuObject.SetActive(false);
        tutorialObject.SetActive(true);
    }
    private void OnCreditsButtonHandler()
    {
        mainMenuObject.SetActive(false);
        creditsObject.SetActive(true);
    }
    private void OnExitButtonHandler()
    {
        Application.Quit();
    }
}
