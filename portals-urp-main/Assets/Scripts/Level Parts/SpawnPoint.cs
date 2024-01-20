using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] bool spawnAtStart;

    private void Awake()
    {
        if (spawnAtStart)
        {
            FindObjectOfType<FirstPersonController>().transform.position = transform.position;
            FindObjectOfType<FirstPersonController>().transform.rotation = transform.rotation;
        }
    }
}
