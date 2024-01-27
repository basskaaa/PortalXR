using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalResetCollider : MonoBehaviour
{
    [SerializeField] private GameEvent resetPortals;
    [SerializeField] private AudioClipHolder resetPortalsAudio;
    [SerializeField] private AudioClipHolder dissolveAudio;
    [SerializeField] private float delay = 0f;
    [SerializeField] private GameEvent destroyBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ClearPortals());
        }

        if (other.gameObject.GetComponent<HoldableItem>() != null && other.gameObject.GetComponent<HoldableItem>().isBox)
        {
            destroyBox.Raise();
            AudioManager.Instance.PlaySound(dissolveAudio.AudioClip, dissolveAudio.Volume);
            other.GetComponent<HoldableItem>().DestroyHoldable();
        }

        if (other.gameObject.GetComponent<HoldableItem>() != null && other.gameObject.GetComponent<HoldableItem>().isTurret)
        {
            AudioManager.Instance.PlaySound(dissolveAudio.AudioClip, dissolveAudio.Volume);
            other.GetComponent<HoldableItem>().DestroyHoldable();
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
