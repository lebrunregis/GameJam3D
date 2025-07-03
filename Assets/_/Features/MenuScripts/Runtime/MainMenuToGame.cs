using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuScripts.Runtime
{
    public class MainMenuToGame : MonoBehaviour
    {
        #region Unity API

        public void LoadScene()
        {
            SceneManager.LoadScene("FinalScene");
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}
