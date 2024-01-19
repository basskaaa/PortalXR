using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] bool isOpenOnStart = false;
    [SerializeField] bool hasTriggerCollider = false;
    [SerializeField] bool hasEventTriggers = false;
    [SerializeField] bool[] trigger;

    private Animator animator;

    [SerializeField] AudioClipHolder openSound;
    [SerializeField] AudioClipHolder closeSound;

    [SerializeField] private GameEvent doorOpenEvent;

    private bool isOpen;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = isOpenOnStart;

        if (isOpenOnStart)
        {
            OpenDoors();
        }
    }

    private void Update()
    {
        if (CheckTriggers() && hasEventTriggers) 
        { 
            OpenDoors();
        }
        if (hasEventTriggers && !CheckTriggers())
        {
            CloseDoors();
        }
    }

    private bool CheckTriggers()
    { 
        foreach (bool t in trigger) 
        { 
            if (!t)
            {
                return false;
            }
        }
        return true;
    }

    public void SetTrigger(int index)
    {
        trigger[index] = true;
    }

    public void UnsetTrigger(int index)
    {
        trigger[index] = false;
    }

    public void OpenDoors()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("Open", true);
            AudioManager.Instance.PlaySound(openSound.AudioClip, openSound.Volume);
            doorOpenEvent.Raise();
            Debug.Log("Open");
        }
    }

    public void CloseDoors()
    {
        if (isOpen)
        { 
            isOpen = false;
            animator.SetBool("Open", false);
            AudioManager.Instance.PlaySound(closeSound.AudioClip, closeSound.Volume);
            Debug.Log("Closed");
        }
    }
}
