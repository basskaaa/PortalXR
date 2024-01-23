using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHere : MonoBehaviour
{
    [SerializeField] public bool spawnHere;
    [SerializeField] public bool hasPortalGun;

    private Transform player;

    private Restart restart;



    protected void Start()
    { 
        player = FindObjectOfType<FirstPersonController>().transform;

        restart = FindObjectOfType<Restart>();
        if (restart != null ) 
        {
            Debug.Log("Found restart");
            restart.spawnHere = this;
        }
        else
        {
            Debug.Log("Not found restart");
        }

        if (spawnHere)
        {
            SetPosition();
        }

        if (hasPortalGun)
        {
            SetPortalGun();
        }
    }

    public void SetPosition()
    {
        player = FindObjectOfType<FirstPersonController>().transform;

        player.position = transform.position;
        player.rotation = transform.rotation;
    }

    public void SetPortalGun()
    {
        GameManager.Instance.playerHasPortalGun = true;
        UiManager.Instance.GetPortalGun();
        FindObjectOfType<PortalPlacement>().canPlacePortals = true;
        //FindObjectOfType<Crosshair>().enabled = true;
    }
}
