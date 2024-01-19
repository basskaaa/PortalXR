using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunBlueCollect : MonoBehaviour
{
    [SerializeField] GameEvent bluePortalGunAcquired;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bluePortalGunAcquired.Raise();
            GameManager.Instance.playerCanShootBlue = true;
            Debug.Log("Blue gun aquired");
            Destroy(gameObject);
        }
    }
}
