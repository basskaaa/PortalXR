using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunCollect : MonoBehaviour, IInteractable
{
    [SerializeField] GameEvent portalGunAcquired;
    [SerializeField] GameEvent resetPortals;

    public void OnInteract()
    {
        CollectGun();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectGun();
        }
    }

    private void CollectGun()
    {
        portalGunAcquired.Raise();
        resetPortals.Raise();
        GameManager.Instance.playerHasPortalGun = true;
        //Debug.Log("Portal gun aquired");
        FindObjectOfType<Crosshair>().transform.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
