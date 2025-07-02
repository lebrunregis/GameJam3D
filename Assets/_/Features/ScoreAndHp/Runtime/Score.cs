using System;
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

            if (coffin.m_coffinType == expectedIndex)
            {
                gameManager.AddScore(1);
                Debug.Log("Bonne zone !");
            }
            else
            {
                gameManager.RemoveHp(1);
                Debug.Log("Mauvaise zone !");
            }

            Destroy(other.gameObject);
        }
        
        #region Unity API
     
        #endregion
        
        
        #region Private
        [SerializeField] private int expectedIndex;
        [SerializeField] private GameManagerScript gameManager;
       

        #endregion
    }
}
