using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<FirstPersonController>().transform.position = transform.position;
        FindObjectOfType<FirstPersonController>().transform.rotation = transform.rotation;
    }
}
