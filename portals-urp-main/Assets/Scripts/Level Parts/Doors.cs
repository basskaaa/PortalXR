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

    bool isOpen = false;

    [SerializeField] AudioClipHolder openSound;
    [SerializeField] AudioClipHolder closeSound;

    [SerializeField] private GameEvent doorOpenEvent;

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
        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("Open", true);
            AudioManager.Instance.PlaySound(openSound.AudioClip, openSound.Volume);
            doorOpenEvent.Raise();
        }
    }

    private void CloseDoors()
    {
        if (isOpen)
        { 
            isOpen = false;
            animator.SetBool("Open", false);
            AudioManager.Instance.PlaySound(closeSound.AudioClip, closeSound.Volume);
        }
    }
}
