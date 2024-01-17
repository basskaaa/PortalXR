using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : Singleton<VoiceManager>
{
    private List<AudioClip> voiceClipList = new List<AudioClip>();
    private List<float> voiceClipDelayList = new List<float>();

    private AudioSource voiceSource;

    private bool isPlaying = false;

    private void Awake()
    {
        voiceSource = GetComponent<AudioSource>();
    }

    public void AddVoiceLineToQueue(VoiceCilpHolder voiceHolder)
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayVoiceQueue(voiceHolder));
        }
    }

    private IEnumerator PlayVoiceQueue(VoiceCilpHolder voiceHolder)
    {
        isPlaying = true;

        for (int i = 0; i < voiceHolder.VoiceLine.Length; i++)
        {
            voiceSource.clip = voiceHolder.VoiceLine[i];
            voiceSource.Play();
            yield return new WaitWhile(() => voiceSource.isPlaying);
            Debug.Log(voiceHolder.VoiceLine[i].name);
            yield return new WaitForSeconds(voiceHolder.VoiceLineDelay[i]);
            Debug.Log(voiceHolder.VoiceLineDelay[i]);
        }
        isPlaying = false;
    }
}
