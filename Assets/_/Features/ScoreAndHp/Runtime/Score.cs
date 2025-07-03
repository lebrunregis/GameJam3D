using GameManager.Runtime;
using LayerChangeCoffin.Runtime;
using UnityEngine;

namespace ScoreAndHp.runtime
{
    public class Score : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            LayerChanger coffin = other.GetComponent<LayerChanger>();
            if (coffin == null) return;

            if (coffin.m_coffinType == expectedType)
            {
                gameManager.AddScore();
                Debug.Log("Bonne zone !");
            }
            else
            {
                gameManager.RemoveHp();
                Debug.Log("Mauvaise zone !");
            }

            Destroy(other.gameObject);
        }

        #region Unity API

        #endregion


        #region Private
        [SerializeField] private LayerChanger.CoffinType expectedType;
        [SerializeField] private GameManagerScript gameManager;
        #endregion
    }
}
