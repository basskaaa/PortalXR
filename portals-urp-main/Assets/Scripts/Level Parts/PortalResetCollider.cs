using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalResetCollider : MonoBehaviour
{
    [SerializeField] private GameEvent resetPortals;
    [SerializeField] private AudioClipHolder resetPortalsAudio;
    [SerializeField] private AudioClipHolder dissolveAudio;
    [SerializeField] private float delay = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ClearPortals());
        }

        if (other.gameObject.CompareTag("Interactable"))
        {
            Destroy(other.gameObject, 0.3f);
            AudioManager.Instance.PlaySound(dissolveAudio.AudioClip, dissolveAudio.Volume);

        }
    }

    private IEnumerator ClearPortals()
    {
        yield return new WaitForSeconds(delay);
        resetPortals.Raise();
        AudioManager.Instance.PlaySound(resetPortalsAudio.AudioClip, resetPortalsAudio.Volume);

        FindObjectOfType<PortalPlacement>().inPortalActive = false;
        FindObjectOfType<PortalPlacement>().outPortalActive = false;
        GameManager.Instance.bothPortalsActive = false;
    }
}
