using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsCollision : MonoBehaviour
{
    public bool resetViaPortal = true;
    public bool resetViaSpawnPoint = false;

    private void OnTriggerEnter(Collider other)
    {
        OutOfBounds(other);
    }

    private void OnTriggerStay(Collider other)
    {
        //OutOfBounds(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OutOfBounds(other);
    }

    private void OutOfBounds(Collider other)
    {
        Debug.Log("Out of bounds");

        if ((other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Interactable")) && resetViaPortal)
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

        if (other.gameObject.CompareTag("Player") && resetViaSpawnPoint)
        {
            FindObjectOfType<Restart>().ResetPos();
        }
    }
}
