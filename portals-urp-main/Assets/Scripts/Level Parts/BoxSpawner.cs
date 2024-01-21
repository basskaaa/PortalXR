using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject box;
    [SerializeField] private AudioClipHolder boxDestroySound;
    [SerializeField] private AudioClipHolder boxSpawnSound;

    public void SpawnBox()
    {
        Box currentBox = FindObjectOfType<Box>();

        if (currentBox != null) 
        { 
            Destroy(currentBox.gameObject);
            AudioManager.Instance.PlaySound(boxDestroySound.AudioClip, boxDestroySound.Volume);
        }

        GameObject clone = box;
        Instantiate(clone, spawnPoint);
        AudioManager.Instance.PlaySound(boxSpawnSound.AudioClip, boxSpawnSound.Volume);
    }
}
