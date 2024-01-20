using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameEvent PauseEvent;
    [SerializeField] private GameEvent ClosePauseEvent;
    [SerializeField] private GameObject portalGun;
    private bool isPaused = false;

    private void Awake()
    {
        //PauseEvent.Raise();
        //isPaused = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (!isPaused) 
            {
                PauseEvent.Raise();
                isPaused = !isPaused;
            }
            else
            {
                ClosePauseEvent.Raise();
                isPaused = !isPaused;
            }
        }
    }

    public void GetPortalGun()
    {
        portalGun.SetActive(true);
    }
}
