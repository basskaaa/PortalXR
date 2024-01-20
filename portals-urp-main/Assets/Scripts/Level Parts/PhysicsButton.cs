using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameEvent buttonPressed;
    [SerializeField] private GameEvent buttonUnpressed;
    [SerializeField] private AudioClipHolder buttonSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ButtonPressed(collision.gameObject);

        AudioManager.Instance.PlaySound(buttonSound.AudioClip, buttonSound.Volume);
    }

    private void OnCollisionStay(Collision collision)
    {
        ButtonPressed(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        ButtonUnpressed(collision.gameObject);
    }

    private void ButtonPressed(GameObject collision)
    {
        if (collision.GetComponent<HoldableItem>() != null || collision.CompareTag("Player"))
        {
            animator.SetBool("Pressed", true);
            buttonPressed.Raise();
            collision.transform.SetParent(transform);
        }
    }

    private void ButtonUnpressed(GameObject collision)
    {
        if (collision.GetComponent<HoldableItem>() != null || collision.CompareTag("Player"))
        {
            animator.SetBool("Pressed", false);
            buttonUnpressed.Raise();
            collision.transform.SetParent(null);
        }
    }
}
