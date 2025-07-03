using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace GameManager.Runtime
{
    public class GameManagerScript : MonoBehaviour
    {

        #region public 
        
        public int m_score = 0;
        
        #endregion
        void Start()
        {

        }


        void Update()
        {
            if (_hp <=0)
            {
                Death();
            }
        }

        #region Utils

        public void AddScore()
        {
            m_score += 1;
            //if (m_score % 20 == 0)
            //{
            //    AddHp();
            //}
        }

        public void RemoveHp()
        {
            if (_hp > 0)
            {
                _hp -= 1;

            }
            
        }

        public void AddHp()
        {
            if (_hp > 0)
            {
                if (_hp < _maxHp)
                {
                    _hp += 1; 
                }
            }
            
            
        }

        public void Death()
        {
            
            // Sauvegarde mais le nom doit être fait dans une autre scene
            //PlayerPrefs.SetString("CurrentPlayerName", playerName);

            // Ajouter au tableau des high scores
            FindObjectOfType<MaxScore.Runtime.HighScoreManager>().SavePendingScore(m_score);
            SceneManager.LoadScene("NameEntering");
        }
        #endregion

        #region private

        public int _hp = 3;
        private int _maxHp = 10;

        #endregion
    }
}
