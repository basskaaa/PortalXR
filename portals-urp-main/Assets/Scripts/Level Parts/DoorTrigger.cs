using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private bool OpensOrCloses = true;
    [SerializeField] private bool Open;

    [SerializeField] GameEvent endLevelEvent;

    [SerializeField] bool isSceneLoader = false;
    [SerializeField] SceneField sceneToLoad;
    [SerializeField] bool isSceneUnloader = false;
    [SerializeField] SceneField sceneToUnload;

    private Doors door;
    private bool loaded = false;
    private bool unloaded = false;

    private void Start()
    {
        door = GetComponentInParent<Doors>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (OpensOrCloses && Open && other.gameObject.CompareTag("Player"))
        {
            door.OpenDoors();
        }
        if (OpensOrCloses && !Open && other.gameObject.CompareTag("Player"))
        {
            door.CloseDoors();
        }

        if (isSceneLoader && !loaded)
        {
            endLevelEvent.Raise();
            SceneSwapManager.Instance.SwapScene(sceneToLoad);
            Debug.Log("Loading: " + sceneToLoad);
            loaded = true;
        }        
        if (isSceneUnloader && !unloaded)
        {
            Player.Instance.SetParent();
            SceneSwapManager.Instance.UnloadScene(sceneToUnload);
            Debug.Log("Unloading: " + sceneToUnload);
            unloaded = true;
        }
    }
}
