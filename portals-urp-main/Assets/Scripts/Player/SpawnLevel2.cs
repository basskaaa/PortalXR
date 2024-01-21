using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel2 : SpawnHere
{
    private void Start()
    {
        GameManager.Instance.playerHasPortalGun = true;
        UiManager.Instance.GetPortalGun();
    }


}
