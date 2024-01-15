using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalResetCollider : MonoBehaviour
{
    [SerializeField] private GameEvent resetPortals;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetPortals.Raise();
        }
    }
}
