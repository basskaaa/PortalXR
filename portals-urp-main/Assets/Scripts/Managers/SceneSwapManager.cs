using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapManager : Singleton<SceneSwapManager>
{
    public void SwapScene(SceneField myScene)
    {
        SceneManager.LoadSceneAsync(myScene, LoadSceneMode.Additive);
    }

    public void UnloadScene(SceneField myScene)
    {
        SceneManager.UnloadSceneAsync(myScene);
    }
}
