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
            Alive = 2
        }

        #endregion

        #region Unity API

        private void OnEnable()
        {
            m_coffinType = RandomType();
        }

        private void OnDisable()
        {
            m_coffinType = CoffinType.None;
        }

        #endregion

        #region Utils

        private CoffinType RandomType()
        {

            int randomNumber = Random.Range((int)CoffinType.None, (int)CoffinType.Alive);
            return (CoffinType)randomNumber;
        }

        public void SetType(CoffinType type)
        {
            m_coffinType = type;
        }

        #endregion



    }


}

