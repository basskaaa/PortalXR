using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisplay : MonoBehaviour
{
    [SerializeField] private Material Material1;
    [SerializeField] private Material Material2;

    public void ChangeMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = Material1;
    }

    public void ChangeMaterial2()
    {
        gameObject.GetComponent<MeshRenderer>().material = Material2;
    }
}
