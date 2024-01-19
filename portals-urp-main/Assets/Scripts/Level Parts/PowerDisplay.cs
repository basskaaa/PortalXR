using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisplay : MonoBehaviour
{
    [SerializeField] private Material PowerMaterial;
    [SerializeField] private Material UnpowerMaterial;
    [SerializeField] private MeshRenderer[] display;


    public void SetPoweredMaterial(int index)
    {
        display[index].material = PowerMaterial;
    }

    public void SetUnpoweredMaterial(int index)
    {
        display[index].material = UnpowerMaterial;
    }
}
