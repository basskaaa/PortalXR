using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalResetCollider : MonoBehaviour
{
    [SerializeField] private GameEvent resetPortals;
    [SerializeField] private AudioClipHolder resetPortalsAudio;
    [SerializeField] private AudioClipHolder dissolveAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            resetPortals.Raise();
            AudioManager.Instance.PlaySound(resetPortalsAudio.AudioClip, resetPortalsAudio.Volume);

            FindObjectOfType<PortalPlacement>().inPortalActive = false;
            FindObjectOfType<PortalPlacement>().outPortalActive = false;
            GameManager.Instance.bothPortalsActive = false;
        }

        if (other.gameObject.CompareTag("Interactable"))
        {
            Destroy(other.gameObject, 0.3f);
            AudioManager.Instance.PlaySound(dissolveAudio.AudioClip, dissolveAudio.Volume);

        }
    }
}
