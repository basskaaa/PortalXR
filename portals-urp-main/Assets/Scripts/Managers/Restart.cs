using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private SceneField persistant;
    [SerializeField] private SceneField[] scenes;

    [SerializeField] int sceneCount = 0;

    [SerializeField] GameEvent portalGunAcquired;

    public void NextScene()
    {
        sceneCount++;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(persistant);
        Debug.Log(sceneCount);
        SceneManager.LoadScene(scenes[sceneCount], LoadSceneMode.Additive);

        SpawnHere spawnHere = FindObjectOfType<SpawnHere>();
        Transform player = FindObjectOfType<Player>().transform;

        if (spawnHere != null)
        {
            spawnHere.spawnHere = true;
            spawnHere.hasPortalGun = true;
            spawnHere.SetPosition();
        }
        else
        {
            Debug.Log("Cant find spawn here");
        }

        Time.timeScale = 1.0f;
        portalGunAcquired.Raise();
        GameManager.Instance.playerHasPortalGun = true;
        FindObjectOfType<Crosshair>().transform.gameObject.SetActive(true);
    }
}
