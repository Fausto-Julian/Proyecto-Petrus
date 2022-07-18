using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Main.Scripts
{
    public class PauseController : MonoBehaviour
    {
        [Header("Reference Buttons")]
        [SerializeField] private Button continueButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button backOptionsButton;
        [SerializeField] private Button backToMenuButton;
        [SerializeField] private Button exitButton;

        [Header("Reference Panels")] 
        [SerializeField] private GameObject pauseMainPanel;
        [SerializeField] private GameObject optionsPanel;
        
        private bool _activeOptionsPanel;
        private bool _pauseMenu;

        private void Awake()
        {
            _activeOptionsPanel = false;
        }

        private void Start()
        {
            continueButton.onClick.AddListener(OnContinueButtonHandler);
            optionsButton.onClick.AddListener(OnOptionsButtonHandler);
            backOptionsButton.onClick.AddListener(OnBackOptionsButtonHandler);
            backToMenuButton.onClick.AddListener(OnBackToMenuButtonHandler);
            exitButton.onClick.AddListener(OnExitButtonHandler);
            
            pauseMainPanel.SetActive(false);
            optionsPanel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_activeOptionsPanel)
                {
                    _activeOptionsPanel = false;
                    optionsPanel.SetActive(false);
                    pauseMainPanel.SetActive(true);
                }
                else
                {
                    GameManager.Instance.SetPause(true);
                    SetPause();
                }
            }
        }

        private void SetPause()
        {
            Time.timeScale = GameManager.Instance.GetPause() ? 0 : 1;

            switch (Cursor.lockState)
            {
                case CursorLockMode.Locked:
                    Cursor.lockState = CursorLockMode.None;
                    break;
                case CursorLockMode.None:
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
            }

            pauseMainPanel.SetActive(GameManager.Instance.GetPause());
            optionsPanel.SetActive(false);
        }

        private void OnContinueButtonHandler()
        {
            GameManager.Instance.SetPause(false);
            SetPause();
        }

        private void OnOptionsButtonHandler()
        {
            pauseMainPanel.SetActive(false);
            optionsPanel.SetActive(true);
            _activeOptionsPanel = true;
        }
        private void OnBackOptionsButtonHandler()
        {
            optionsPanel.SetActive(false);
            pauseMainPanel.SetActive(true);
        }
        
        private void OnBackToMenuButtonHandler()
        {
            SceneManager.LoadScene(0);
        }
        
        private void OnExitButtonHandler()
        {
            Application.Quit();
        }
    }
}