using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuScripts.Runtime
{
    public class MainMenuToGame : MonoBehaviour
    {
        #region Unity API

        public void LoadScene()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion
    }
}
