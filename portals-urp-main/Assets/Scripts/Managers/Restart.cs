using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private SceneField persistant;
    [SerializeField] private SceneField[] scenes;
    public SpawnHere spawnHere;

    [SerializeField] int sceneCount = 0;

    [SerializeField] GameEvent portalGunAcquired;
    [SerializeField] GameEvent resetPortals;

    Transform oldParent;


    private void Awake()
    {
        oldParent = FindObjectOfType<Player>().transform.parent;
    }

    public void NextScene()
    {
        Debug.Log("Next scene");

        sceneCount++;
    }

    public void RestartScene()
    {
        resetPortals.Raise();
        Debug.Log(sceneCount);
        FindObjectOfType<Player>().gameObject.transform.SetParent(oldParent);
        SceneSwapManager.Instance.UnloadScene(scenes[sceneCount]);

        spawnHere.SetPosition();
        //spawnHere[spawnIndex].SetPortalGun();
        Debug.Log("spawned at " + sceneCount);

        Time.timeScale = 1.0f;
        SceneSwapManager.Instance.SwapScene(scenes[sceneCount]);
        //portalGunAcquired.Raise();
    }
}
