using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoors()
    {
        animator.SetBool("Open", true);
    }

    public void CloseDoors()
    {
        animator.SetBool("Open", false);
    }
}
