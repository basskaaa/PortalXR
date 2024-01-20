using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Interactable"))
        {
            PortalableObject portalableObject = FindObjectOfType<PortalableObject>();
            Transform lastPortalTf = portalableObject.lastPortalTf.transform;
            Debug.Log(other.gameObject.name + " out of bounds");

            if (!portalableObject.IsPortalOnCeiling()) 
            {
                other.gameObject.transform.position = portalableObject.lastPortalTf.transform.position;
            }
            else
            {
                other.gameObject.transform.position = new Vector3(lastPortalTf.transform.position.x, lastPortalTf.transform.position.y - portalableObject.ceilingClippingLenth, lastPortalTf.transform.position.z);
            }
        }

        if (other.gameObject.CompareTag("Interactable"))
        {
            //Destroy and respawn
        }
    }
}
