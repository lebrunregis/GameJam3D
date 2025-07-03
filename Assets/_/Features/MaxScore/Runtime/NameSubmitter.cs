using UnityEngine;
using TMPro;
namespace MaxScore.Runtime
{
    public class NameSubmitter : MonoBehaviour
    {
        public TMP_InputField nameInputField;

        public void OnSubmit()
        {
            string name = nameInputField.text;

            if (name.Length > 5 || string.IsNullOrWhiteSpace(name))
            {
                name = "CLOWN";
            }
            FindObjectOfType<MaxScore.Runtime.HighScoreManager>().InsertPendingScoreWithName(name);

            UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
        }
    }
}
