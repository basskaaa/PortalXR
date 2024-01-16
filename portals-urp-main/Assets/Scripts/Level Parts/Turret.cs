using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject eye;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<FirstPersonController>().transform;
        eye = GetComponentInChildren<TurretEye>().gameObject;
    }

    private void Update()
    {
        //EyeLook();
    }

    private void EyeLook()
    {
        eye.transform.LookAt(player.transform.position, Vector3.up);
        eye.transform.Rotate(0, 90, 90);
    }
}
