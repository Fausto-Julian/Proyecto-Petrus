using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button backToMainMenuButton;
    [SerializeField] private Button exitButton;

    private void Start()
    {
        retryButton.onClick.AddListener(OnRetryClicked);
        backToMainMenuButton.onClick.AddListener(OnBackToMainMenuClicked);
        exitButton.onClick.AddListener(OnExitClicked);
    }

    private void OnRetryClicked() => SceneManager.LoadScene(1);
    private void OnBackToMainMenuClicked() => SceneManager.LoadScene(0);
    private void OnExitClicked() => Application.Quit();
}