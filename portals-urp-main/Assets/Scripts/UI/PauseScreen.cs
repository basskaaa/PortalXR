using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        FindObjectOfType<FirstPersonController>().cameraCanMove = false;
        FindObjectOfType<FirstPersonController>().playerCanMove = false;
        FindObjectOfType<FirstPersonController>().lockCursor = false;
        FindObjectOfType<PortalPlacement>().canPlacePortals = false;

    }

    public void ContinueFromPaused()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        FindObjectOfType<FirstPersonController>().cameraCanMove = true;
        FindObjectOfType<FirstPersonController>().playerCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PortalPlacement>().canPlacePortals = true;
    }
}
