using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnding : MonoBehaviour
{
    [SerializeField] private AudioClipHolder outroMusic;
    private GameObject credits;

    private void Start()
    {
        credits = FindObjectOfType<Credits>().credits;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusic(outroMusic.AudioClip, outroMusic.Volume);
            credits.SetActive(true);
        }
    }
}
