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
            other.GetComponent<Rigidbody>().AddForce(direction.transform.forward * force, ForceMode.Force);
            AudioManager.Instance.PlaySound(launchSound.AudioClip, launchSound.Volume);
        }
    }
}
