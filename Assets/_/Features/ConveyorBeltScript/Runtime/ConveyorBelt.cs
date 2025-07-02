using ConveyorBeltScript.Runtime;
using System.Collections.Generic;
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

        for (int i = 0; i < GOOnBelt.Count; i++)
        {
            Rigidbody rb = GOOnBelt[i].gameObject.GetComponent<Rigidbody>();
            Grabable grabable = GOOnBelt[i].gameObject.GetComponent<Grabable>();
            if (grabable.grabbed == true)
            {
                GOOnBelt.Remove(GOOnBelt[i]);
                rb.freezeRotation = false;
            }
            else
            {
                rb.linearVelocity = direction;
            }
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
        Grabable grabable = collision.gameObject.GetComponent<Grabable>();
        if (grabable.grabbed == false)
        {
            GOOnBelt.Add(collision.gameObject);
            rb.freezeRotation = true;
        }
    }

    // When something leaves the belt
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        Grabable grabable = collision.gameObject.GetComponent<Grabable>();
        GOOnBelt.Remove(collision.gameObject);
        rb.freezeRotation = false;
    }
    #endregion


    #region Private

    [SerializeField]
    private Vector2 textureScrollSpeed;
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private List<GameObject> GOOnBelt = new();

    private Material material;

    #endregion
}
