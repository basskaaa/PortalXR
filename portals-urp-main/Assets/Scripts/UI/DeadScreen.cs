using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    public void EnableDeathScreen()
    {
        StartCoroutine(WaitToEnable());
    }

    private IEnumerator WaitToEnable()
    {
        yield return new WaitForSeconds(3f);
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
