using UnityEngine;
using TMPro;
namespace MaxScore.Runtime
{
    public class HighScoreDisplay : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        void Start()
        {
            var manager = FindObjectOfType<HighScoreManager>();
            int[] scores = manager.LoadHighScores();
            string[] names = manager.LoadHighScoreNames();

            string display = "High Scores\n\n";
            for (int i = 0; i < scores.Length; i++)
            {
                display += $"{i + 1}. {names[i]} - {scores[i]}\n";
            }

            scoreText.text = display;
        }
    }
}
