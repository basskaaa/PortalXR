using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColliderSize : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    private BoxCollider collider;

    [SerializeField] private float slowSize = 2f;
    [SerializeField] private float fastSize = 5f;

    private Vector3 size;


    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        size = collider.size;
    }

    private void Update()
    {
        //Debug.Log(playerRb.velocity);

        if (playerRb.velocity.x < 10 && playerRb.velocity.x < 10 && playerRb.velocity.x < 10 && playerRb.velocity.x > -10 && playerRb.velocity.x > -10 && playerRb.velocity.x > -10)
        {
            collider.size = new Vector3 (size.x, size.y, slowSize);
        }
        else
        {
            Debug.Log(playerRb.velocity);

            collider.size = new Vector3(size.x, size.y, fastSize);
        }
    }
}
