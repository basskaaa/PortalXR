using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Image deathMask;

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
            deathMask.DOFade(0.2f, 3f);
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
        GameManager.Instance.playerIsAlive = true;
        DisableDeathScreen();
        restart.ResetPos();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void DisableDeathScreen()
    {
        Debug.Log("disabled death screen");
        deathMask.DOFade(0f, 0f);
        deathScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
