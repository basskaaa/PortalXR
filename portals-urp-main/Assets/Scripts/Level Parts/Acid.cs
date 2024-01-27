using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Acid : MonoBehaviour
{
    [SerializeField] private GameEvent playerDied;
    [SerializeField] private float floatGrav;

    [SerializeField] private GameEvent boxDestroyed;
    [SerializeField] private AudioClipHolder dissolveSound;
    private ConstantForce force;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Restart>().ResetPos();
        }

        if (other.gameObject.GetComponent<HoldableItem>() != null && other.gameObject.GetComponent<HoldableItem>().isBox)
        {
            boxDestroyed.Raise();
            AudioManager.Instance.PlaySound(dissolveSound.AudioClip, dissolveSound.Volume);
            other.GetComponent<HoldableItem>().DestroyHoldable();
        }

        if (other.gameObject.GetComponent<HoldableItem>() != null && other.gameObject.GetComponent<HoldableItem>().isTurret)
        {
            AudioManager.Instance.PlaySound(dissolveSound.AudioClip, dissolveSound.Volume);

            other.GetComponent<HoldableItem>().DestroyHoldable();
        }
    }
}
