using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool playerHasPortalGun = false;
    public bool playerCanShootBlue = false;
    public bool bothPortalsActive;
    public bool playerCanDie = true;
    public bool playerIsAlive = true;
    public bool playerIsActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Escape)) 
        { 
            playerIsActive = true;
        }
    }
}
