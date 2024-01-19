using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private bool Open;

    private Doors door;

    private void Start()
    {
        door = GetComponentInParent<Doors>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Open && other.gameObject.CompareTag("Player"))
        {
            door.OpenDoors();
        }
        if (!Open && other.gameObject.CompareTag("Player"))
        {
            door.CloseDoors();
        }
    }
}
