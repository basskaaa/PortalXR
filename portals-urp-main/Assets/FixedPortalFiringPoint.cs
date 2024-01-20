using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPortalFiringPoint : MonoBehaviour
{
    private PortalPlacement portal;
    [SerializeField] private bool isBlue;

    private void Start()
    {
        portal = FindObjectOfType<PortalPlacement>();

        StartCoroutine(SetPortal());
    }

    private IEnumerator SetPortal()
    {
        yield return new WaitForSeconds(1f);
        if (!isBlue)
        {
            portal.FirePortal(1, transform.position, transform.forward, 250.0f);
            //portal.outPortalActive = true;
            //Debug.Log("Firing blue");
        }
        else
        {
            portal.FirePortal(0, transform.position, transform.forward, 250.0f);
            //portal.inPortalActive = true;
            //Debug.Log("Firing orange");
        }

        //GameManager.Instance.bothPortalsActive = true;
    }
}
