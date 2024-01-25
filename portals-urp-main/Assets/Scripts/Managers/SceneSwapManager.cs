using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : Singleton<SceneSwapManager>
{
    public void SwapScene(SceneField myScene)
    {
        Debug.Log("Loading " + myScene.SceneName);
        SceneManager.LoadSceneAsync(myScene, LoadSceneMode.Additive);
    }

    public void UnloadScene(SceneField myScene)
    {
        Debug.Log("Unloading " + myScene.SceneName);
        SceneManager.UnloadSceneAsync(myScene);
    }
}
