using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameEvent buttonPressed;
    [SerializeField] private GameEvent buttonUnpressed;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Box>() != null || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Button");
            animator.SetBool("Pressed", true);
            buttonPressed.Raise();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Box>() != null || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Button");
            animator.SetBool("Pressed", false);
            buttonUnpressed.Raise();
        }
    }
}
