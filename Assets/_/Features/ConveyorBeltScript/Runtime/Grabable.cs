using UnityEngine;

namespace ConveyorBeltScript.Runtime
{
    public class Grabable : MonoBehaviour
    {
        public bool grabbed = false;

        private void OnEnable()
        {
            grabbed = false;
        }

        private void OnDisable()
        {
            grabbed = false;
        }
    }
}
