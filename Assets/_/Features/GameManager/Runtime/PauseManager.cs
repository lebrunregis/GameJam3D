using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace GameManager.Runtime
{
    public class PauseManager : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        private bool isPaused = false;

        private void Start()
        {
            pauseMenuUI.SetActive(false);
        }

        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f; // Pause le jeu
                pauseMenuUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f; // Reprend le jeu
                pauseMenuUI.SetActive(false);
            }
        }

        public void ResumeGame()
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }

        public void QuitGame()
        {
            Time.timeScale = 1f; // Important : reset le time scale
            SceneManager.LoadScene("MainMenu"); // Remplace par ta scène
        }
    }
}
