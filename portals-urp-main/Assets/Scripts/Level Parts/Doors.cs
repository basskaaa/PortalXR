using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator animator;
    private int powerLevel;

    bool used1;
    bool used2;
    bool used3;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (used1 && used2 && used3) 
        { 
            OpenDoors();
        }
        else
        {
            CloseDoors();
        }
    }

    public void PButtonDown()
    {
        used3 = true;
    }

    public void PButtonUp()
    {
        used3 = false;
    }

    public void IButton1On()
    {
        used1 = true;
    }

    public void IButton2On()
    {
        used2 = true;
    }

    private void OpenDoors()
    {
        animator.SetBool("Open", true);
    }

    private void CloseDoors()
    {
        animator.SetBool("Open", false);
    }
}
