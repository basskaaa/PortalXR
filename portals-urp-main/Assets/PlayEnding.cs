using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnding : MonoBehaviour
{
    [SerializeField] private AudioClipHolder outroMusic;
    private Credits credits;
    private GameObject scroll;

    private void Start()
    {
        credits = FindObjectOfType<Credits>();
        scroll = credits.credits;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusic(outroMusic.AudioClip, outroMusic.Volume);
            StartCoroutine(PlayCredits());
        }
    }

    private IEnumerator PlayCredits()
    {
        yield return new WaitForSeconds(5f);
        scroll.SetActive(true);
        credits.GetComponent<Animator>().SetTrigger("Play");

    }
}
