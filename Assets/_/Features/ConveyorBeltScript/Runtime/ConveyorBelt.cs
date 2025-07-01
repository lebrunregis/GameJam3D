using System.Collections.Generic;
using ConveyorBeltScript.Runtime;
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
        for (int i = 0; i < GOOnBelt.Count; i++)
        {
            Rigidbody rb = GOOnBelt[i].gameObject.GetComponent<Rigidbody>();
            Grabable grabable = GOOnBelt[i].gameObject.GetComponent<Grabable>();
            if (grabable.grabbed == true)
            {
                GOOnBelt.Remove(GOOnBelt[i]);
            }
            else
            {
                rb.MovePosition(rb.position + movement);
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

        GOOnBelt.Add(collision.gameObject);
        rb.useGravity = false;
    }

    // When something leaves the belt
    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        Grabable grabable = collision.gameObject.GetComponent<Grabable>();
        GOOnBelt.Remove(collision.gameObject);
        rb.useGravity = true;
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
