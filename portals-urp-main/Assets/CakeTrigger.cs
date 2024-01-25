using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeTrigger : MonoBehaviour
{
    private Light light;

    private void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            light.enabled = true;
        }
    }
}
