using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField] private GameEvent buttonPressed;
    [SerializeField] private AudioClipHolder buttonSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void ButtonPressed()
    {
        AudioManager.Instance.PlaySound(buttonSound.AudioClip, buttonSound.Volume);
        animator.SetTrigger("Pressed");
        buttonPressed.Raise();
    }

    public void OnInteract()
    {
        ButtonPressed();
    }
}
