using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseStartGameEvent : MonoBehaviour
{
    public GameEvent startGameEvent;

    private void Start()
    {
        startGameEvent.Raise();
    }
}
