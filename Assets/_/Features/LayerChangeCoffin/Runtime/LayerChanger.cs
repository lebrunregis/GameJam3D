using ShakingCoffin.Runtime;
using UnityEngine;


namespace LayerChangeCoffin.Runtime
{
    [RequireComponent(typeof(Shaking))]
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
        }

        public Shaking m_shaker;
        public bool m_isShaking;
        
        #endregion

        #region Unity API

        private void OnEnable()
        {
            m_shaker = GetComponent<Shaking>();
            m_coffinType = RandomType();
            if (m_coffinType == CoffinType.Alive)
            {
                m_shaker.enabled = true;
                m_isShaking = true;
            }else
            {
                m_shaker.enabled = false;
                m_isShaking= false;
            }
        }

        private void OnDisable()
        {
           m_coffinType = CoffinType.None;
            m_isShaking = false;
            m_shaker.enabled=false;
        }

        #endregion

        #region Utils

        private CoffinType RandomType()
        {

            int randomNumber = Random.Range((int)CoffinType.Evil, (int)CoffinType.Alive+1);
            return (CoffinType)randomNumber;
        }

        public void SetType(CoffinType type)
        {
            if(type != CoffinType.Alive)
            {
                m_coffinType = type;
            }
            Debug.Log("Coffin type :" + m_coffinType);
        }

        #endregion



    }


}

