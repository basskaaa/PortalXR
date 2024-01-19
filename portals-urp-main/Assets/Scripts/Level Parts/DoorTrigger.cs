using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private bool Open;

    [SerializeField] GameEvent endLevelEvent;

    [SerializeField] bool isSceneLoader = false;
    [SerializeField] SceneField sceneToLoad;
    [SerializeField] bool isSceneUnloader = false;
    [SerializeField] SceneField sceneToUnload;

    private Doors door;

    private void Start()
    {
        door = GetComponentInParent<Doors>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Open && other.gameObject.CompareTag("Player"))
        {
            door.OpenDoors();
        }
        if (!Open && other.gameObject.CompareTag("Player"))
        {
            door.CloseDoors();
        }
        if (isSceneLoader)
        {
            endLevelEvent.Raise();
            SceneSwapManager.Instance.SwapScene(sceneToLoad);
            Debug.Log("Loading: " + sceneToLoad);
        }        
        if (isSceneUnloader)
        {
            SceneSwapManager.Instance.UnloadScene(sceneToUnload);
            Debug.Log("Unloading: " + sceneToUnload);
        }
    }
}
