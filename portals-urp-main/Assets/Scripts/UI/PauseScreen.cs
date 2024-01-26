using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    private Restart restart;

    private void Start()
    {
        restart = GetComponentInParent<Restart>();
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        FindObjectOfType<PlayerCamera>().cameraCanMove = false;
        FindObjectOfType<PlayerCamera>().lockCursor = false;
        FindObjectOfType<FirstPersonController>().playerCanMove = false;
        FindObjectOfType<PortalPlacement>().canPlacePortals = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ContinueFromPaused()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        FindObjectOfType<PlayerCamera>().cameraCanMove = true;
        FindObjectOfType<FirstPersonController>().playerCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PortalPlacement>().canPlacePortals = true;
    }

    public void RestartGame()
    {
        PauseMenu.SetActive(false);
        FindObjectOfType<PlayerCamera>().cameraCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        restart.RestartScene();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
