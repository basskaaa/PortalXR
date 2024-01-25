using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] objectEnabled;
    [SerializeField] GameObject[] objectDisabled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject go in objectEnabled) 
            { 
                go.SetActive(true);
            }

            foreach (GameObject go in objectDisabled)
            {
                go.SetActive(false);
            }
        }
    }
}
