using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    private Animator animator;
    [SerializeField] private GameEvent buttonPressed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void ButtonPressed()
    {
        animator.SetTrigger("Pressed");
        buttonPressed.Raise();
    }

    public void OnInteract()
    {
        ButtonPressed();
    }
}
