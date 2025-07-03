using GameManager.Runtime;
using TMPro;
using UnityEngine;

namespace ScoreDisplayInGame.Runtime
{
    public class ScoreUI : MonoBehaviour
    {
        #region Unity API
        void Start()
        {
        
        }

        
        void Update()
        {
            if (_getScore != null)
            {
                _scoreText.text = "Score: " + _getScore.m_score.ToString();
            }
        }
        
        #endregion
        
        #region Private
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField]private GameManagerScript _getScore;
        
        #endregion
    }
}
