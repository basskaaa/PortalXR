using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] SceneField persistantScene;
    [SerializeField] SceneField[] sceneToLoad;

    public void LoadStartingScenes()
    {
        SceneManager.LoadSceneAsync(persistantScene);

        foreach (SceneField scene in sceneToLoad)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
