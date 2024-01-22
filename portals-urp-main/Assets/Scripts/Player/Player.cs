using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private Transform parent;

    private void Start()
    {
        parent = transform.parent;
    }

    public void SetParent()
    {
        gameObject.transform.SetParent(parent);
    }
}
