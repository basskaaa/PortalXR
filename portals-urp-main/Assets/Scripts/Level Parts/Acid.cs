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
            playerDied.Raise();
            player = other.gameObject;
            player.GetComponent<Rigidbody>().useGravity = false;
            force = other.gameObject.AddComponent<ConstantForce>();

            StartCoroutine(FloatBob(force));
        }

        if (other.gameObject.CompareTag("Interactable"))
        {
            boxDestroyed.Raise();
            AudioManager.Instance.PlaySound(dissolveSound.AudioClip, dissolveSound.Volume);
            other.gameObject.AddComponent<ConstantForce>();
            StartCoroutine(FloatBob(other.gameObject.GetComponent<ConstantForce>()));
            other.GetComponent<HoldableItem>().DestroyHoldable();
        }
    }

    public IEnumerator FloatBob(ConstantForce force)
    {
        if (force != null)
        {
            force.force = new Vector3(0, floatGrav, 0);
            yield return new WaitForSeconds(0.5f);
            force.force = new Vector3(0, -floatGrav * 2, 0);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(FloatBob(force));
        }
    }

    public void StopFloat()
    {
        player.GetComponent<Rigidbody>().useGravity = true;
        force.enabled = false;
    }
}
