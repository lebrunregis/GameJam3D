using System.Collections;
using UnityEngine;

namespace ShakingCoffin.Runtime
{
    public class Shaking : MonoBehaviour
    {


        #region Unity API

        private void Start()
        {
            _timeBetweenShaking = Random.Range(1.2f, 1.8f);
            _rb = GetComponent<Rigidbody>();

        }

        private void Update()
        {

            _countDown += Time.deltaTime;

            if (_timeBetweenShaking <= _countDown)
            {
                _timeBetweenShaking = Random.Range(1.2f, 1.8f);
                StartCoroutine(ShakingFunction());
                _countDown = 0;
            }

        }

        #endregion

        #region Utils

        private IEnumerator ShakingFunction()
        {
            _rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
            transform.Rotate(0f, 20f, 0f);
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0f, -40f, 0f);
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(0f, 20f, 0f);


        }


        #endregion


        #region Private

        private Rigidbody _rb;
        private float _countDown;
        private float _timeBetweenShaking;


        #endregion
    }
}
