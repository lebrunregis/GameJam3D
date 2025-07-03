using ShakingCoffin.Runtime;
using UnityEngine;

namespace LayerChangeCoffin.Runtime
{
    public class LayerChanger : MonoBehaviour
    {
        #region public

        public CoffinType m_coffinType { get; private set; }
        public enum CoffinType
        {
            None = -1,
            Evil = 0,
            Good = 1,
            Alive = 2,
            Test = 3
            
        }

        public Shaking m_isShaking;
        
        #endregion

        #region Unity API

        private void OnEnable()
        {
            m_isShaking = GetComponent<Shaking>();
            m_isShaking.enabled = false;
            m_coffinType = RandomType();
            if (m_coffinType == CoffinType.Alive)
            {
                m_isShaking.enabled = true;
            }
        }

        private void OnDisable()
        {
            m_coffinType = CoffinType.None;
        }

        #endregion

        #region Utils

        private CoffinType RandomType()
        {

            int randomNumber = Random.Range((int)CoffinType.None, (int)CoffinType.Test);
            return (CoffinType)randomNumber;
        }

        public void SetType(CoffinType type)
        {
            m_coffinType = type;
        }

        #endregion



    }


}

