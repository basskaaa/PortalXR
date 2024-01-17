using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalResetCollider : MonoBehaviour
{
    [SerializeField] private GameEvent resetPortals;
    [SerializeField] private AudioClipHolder resetPortalsAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetPortals.Raise();
            AudioManager.Instance.PlaySound(resetPortalsAudio.AudioClip, resetPortalsAudio.Volume);
        }

        if (other.gameObject.CompareTag("Interactable"))
        {
            Destroy(other.gameObject, 0.3f);
        }
    }
}
