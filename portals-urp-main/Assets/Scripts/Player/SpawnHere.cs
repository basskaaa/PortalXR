using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHere : MonoBehaviour
{
    [SerializeField] private bool spawnHere;
    [SerializeField] private bool hasPortalGun;

    private Transform player;

    protected void Awake()
    { 
        player = FindObjectOfType<FirstPersonController>().transform;

        if (spawnHere)
        {
            SetPosition();
        }

        if (hasPortalGun)
        {
            GameManager.Instance.playerHasPortalGun = true;
            UiManager.Instance.GetPortalGun();
            FindObjectOfType<PortalPlacement>().canPlacePortals = true;
            FindObjectOfType<Crosshair>().enabled = true;
        }
    }

    private void SetPosition()
    {
        player.position = transform.position;
        player.rotation = transform.rotation;
    }
}
