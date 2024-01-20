using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalColliderSize : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    private BoxCollider portalCollider;

    [SerializeField] private float slowSize = 2f;
    [SerializeField] private float fastSize = 5f;

    private Vector3 size;


    private void Start()
    {
        portalCollider = GetComponent<BoxCollider>();
        playerRb = FindObjectOfType<FirstPersonController>().gameObject.GetComponent<Rigidbody>();
        size = portalCollider.size;
    }

    private void Update()
    {
        //Debug.Log(playerRb.velocity);

        if (playerRb.velocity.x < 10 && playerRb.velocity.x < 10 && playerRb.velocity.x < 10 && playerRb.velocity.x > -10 && playerRb.velocity.x > -10 && playerRb.velocity.x > -10)
        {
            portalCollider.size = new Vector3 (size.x, size.y, slowSize);
        }
        else
        {
            portalCollider.size = new Vector3(size.x, size.y, fastSize);
        }
    }
}
