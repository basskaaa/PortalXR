using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformActivate : MonoBehaviour
{
    [SerializeField] private GameEvent activate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activate.Raise();
        }
    }
}
