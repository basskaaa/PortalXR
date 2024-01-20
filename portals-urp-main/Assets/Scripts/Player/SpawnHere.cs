using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHere : MonoBehaviour
{
    [SerializeField] private bool spawnHere;

    private Transform player;

    protected virtual void Awake()
    { 
        player = FindObjectOfType<FirstPersonController>().transform;

        if (spawnHere)
        {
            SetPosition();
        }
    }

    protected virtual void SetPosition()
    {
        player.position = transform.position;
        player.rotation = transform.rotation;
    }
}
