using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private bool OpensOrCloses = true;
    [SerializeField] private bool Open;
    [SerializeField] private bool OverrideButtons = false;

    [SerializeField] GameEvent endLevelEvent;

    [SerializeField] bool isSceneLoader = false;
    [SerializeField] SceneField sceneToLoad;
    [SerializeField] bool isSceneUnloader = false;
    [SerializeField] SceneField sceneToUnload;
    [SerializeField] bool isEndLevel = false;

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
            if (OverrideButtons)
            {
                door.hasTriggeredFinal = true;
            }
        }
        if (OpensOrCloses && !Open && other.gameObject.CompareTag("Player"))
        {
            door.CloseDoors();
            if (OverrideButtons)
            {
                door.hasTriggeredFinal = true;
            }
        }

        if (isSceneLoader && !loaded)
        {
            if (sceneToLoad != null) SceneSwapManager.Instance.SwapScene(sceneToLoad);
            loaded = true;
        }        
        if (isSceneUnloader && !unloaded)
        {
            Player.Instance.SetParent();
            SceneSwapManager.Instance.UnloadScene(sceneToUnload);
            //Debug.Log("Unloading: " + sceneToUnload);
            unloaded = true;
        }

        if (isEndLevel)
        {
            endLevelEvent.Raise();
            //Debug.Log("End of level");
        }
    }
}
