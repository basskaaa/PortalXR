using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadElevator : MonoBehaviour
{
    [SerializeField] private SceneField Elevator;

    public void LoadElevatorOnEvent()
    {
        SceneSwapManager.Instance.SwapScene(Elevator);
    }
}
