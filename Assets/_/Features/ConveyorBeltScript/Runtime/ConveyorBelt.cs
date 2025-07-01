using System.Collections.Generic;
using Codice.CM.Common;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    #region Unity API


    private void Start()
    {
        /* Create an instance of this texture
         * This should only be necessary if the belts are using the same material and are moving different speeds
         */
        material = GetComponent<MeshRenderer>().material;
    }


    private void Update()
    {
        // Move the conveyor belt texture to make it look like it's moving
        material.mainTextureOffset += textureScrollSpeed * Time.deltaTime;
        Vector3 movement = direction * Time.deltaTime;
        foreach (Rigidbody rb in onBelt)
        {
            rb.position += movement;
        }
    }

    // Fixed update for physics
    private void FixedUpdate()
    {
    }

    // When something collides with the belt
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Coffin on collider");
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        onBelt.Add(rb);
    }

    // When something leaves the belt
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        onBelt.Remove(rb);
    }


    #endregion


    #region Private

    [SerializeField]
    private Vector2 textureScrollSpeed;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private List<Rigidbody> onBelt;

    private Material material;

    #endregion
}
