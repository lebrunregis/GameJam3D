using UnityEngine;

namespace MaxScore.Runtime
{
    public class HighScoreManager : MonoBehaviour
    {
        public int maxHighScores = 10;

        public void SavePendingScore(int score)
        {
            PlayerPrefs.SetInt("PendingScore", score);
            PlayerPrefs.Save();
        }

        public void InsertPendingScoreWithName(string playerName)
        {
            int score = PlayerPrefs.GetInt("PendingScore", -1);
            if (score == -1)
            {
                Debug.LogWarning("Aucun score en attente trouvé !");
                return;
            }

            playerName = playerName.Length > 5 ? playerName.Substring(0, 5) : playerName;

            int[] scores = LoadHighScores();
            string[] names = LoadHighScoreNames();

            for (int i = 0; i < maxHighScores; i++)
            {
                if (score > scores[i])
                {
                    for (int j = maxHighScores - 1; j > i; j--)
                    {
                        scores[j] = scores[j - 1];
                        names[j] = names[j - 1];
                    }

                    scores[i] = score;
                    names[i] = playerName;

                    SaveHighScores(scores, names);
                    PlayerPrefs.DeleteKey("PendingScore");
                    PlayerPrefs.Save();
                    return;
                }
            }

            PlayerPrefs.DeleteKey("PendingScore");
            PlayerPrefs.Save();
        }

        public int[] LoadHighScores()
        {
            int[] scores = new int[maxHighScores];
            for (int i = 0; i < maxHighScores; i++)
            {
                scores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
            }
            return scores;
        }

        public string[] LoadHighScoreNames()
        {
            string[] names = new string[maxHighScores];
            for (int i = 0; i < maxHighScores; i++)
            {
                names[i] = PlayerPrefs.GetString("HighScoreName" + i, "---");
            }
            return names;
        }

        private void SaveHighScores(int[] scores, string[] names)
        {
            for (int i = 0; i < maxHighScores; i++)
            {
                PlayerPrefs.SetInt("HighScore" + i, scores[i]);
                PlayerPrefs.SetString("HighScoreName" + i, names[i]);
            }
            PlayerPrefs.Save();
        }
    }
}
