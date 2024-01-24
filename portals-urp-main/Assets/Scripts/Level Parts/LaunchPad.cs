using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    private Animator animator;
    private LaunchPadDirection direction;

    [SerializeField] private float force;
    [SerializeField] AudioClipHolder launchSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        direction = GetComponentInChildren<LaunchPadDirection>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<PortalableObject>();

        if (obj != null)
        {
            animator.SetTrigger("Launch");
            //other.GetComponent<Rigidbody>().AddForce(direction.transform.forward * force, ForceMode.Force);
            other.GetComponent<Rigidbody>().AddForce(direction.transform.forward * force, ForceMode.Impulse);
            AudioManager.Instance.PlaySound(launchSound.AudioClip, launchSound.Volume);
            if (other.GetComponent<FirstPersonController>() != null)
            {
                StartCoroutine(DisableController(other.gameObject));
            }
        }
    }

    private IEnumerator DisableController(GameObject player)
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<PlayerCamera>().enabled = false;
        yield return new WaitForSeconds(1f);
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<PlayerCamera>().enabled = true;
    }
}
