using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsButton : MonoBehaviour
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
            StartCoroutine(UnpressedDelay(collision.gameObject));
        }
    }

    private IEnumerator UnpressedDelay(GameObject collision)
    {
        yield return new WaitForSeconds(0.1f);

        if (collision.GetComponent<Box>() != null || collision.CompareTag("Player"))
        {
            Debug.Log("Button");
            animator.SetBool("Pressed", false);
            buttonUnpressed.Raise();
        }
    }
}
