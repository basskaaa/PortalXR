using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    [SerializeField] private bool isPlayOnStart = false;
    [SerializeField] private bool isTriggerCollider = false;
    [SerializeField] private bool isEvent = false;

    [SerializeField] private VoiceCilpHolder voiceHolder;

    private void Start()
    {
        if (isPlayOnStart) 
        {
            VoiceManager.Instance.AddVoiceLineToQueue(voiceHolder);
            Debug.Log("Trigger");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isTriggerCollider)
        {
            VoiceManager.Instance.AddVoiceLineToQueue(voiceHolder);
        }
    }

    public void EventVoiceLine()
    {
        if (isEvent) 
        {
            VoiceManager.Instance.AddVoiceLineToQueue(voiceHolder);
        }
    }
}
