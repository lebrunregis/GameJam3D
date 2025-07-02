using Codice.CM.Common.Tree;
using UnityEngine;

namespace LayerChangeCoffin.Runtime
{
    public class LayerChanger : MonoBehaviour
    {
        #region public

        public int m_coffinType { get; private set; }

        #endregion

        #region Unity API
        
        private void OnEnable()
        {
           m_coffinType=ChangeNumber();
        }

        private void OnDisable()
        {
            m_coffinType = -1;
        }

        #endregion

        #region Utils

        private int ChangeNumber()
        {

        int changeNumber;
        changeNumber = Random.Range(0,3);
        

        return changeNumber;
        }

        #endregion
        
        
      
    }
    
          
}

