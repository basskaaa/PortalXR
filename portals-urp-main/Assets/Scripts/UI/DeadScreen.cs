using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    private Restart restart;

    private void Start()
    {
        restart = GetComponentInParent<Restart>();
    }

    private void Update()
    {
        if (GameManager.Instance.playerIsAlive)
        {
            deathScreen.SetActive(false);
        }
    }

    public void EnableDeathScreen()
    {
        if (GameManager.Instance.playerCanDie)
        {
            StartCoroutine(WaitToEnable());
        }
    }

    private IEnumerator WaitToEnable()
    {
        yield return new WaitForSeconds(3f);
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        restart.RestartScene();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void DisableDeathScreen()
    {
        deathScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
