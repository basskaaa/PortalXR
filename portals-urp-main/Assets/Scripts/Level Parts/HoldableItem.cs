using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableItem : MonoBehaviour, IInteractable
{
    private Transform holdPosition;
    private Rigidbody rigidbody;

    [HideInInspector] public bool isHeld = false;

    public void OnInteract()
    {
        Debug.Log("Interact");
        if (!isHeld) SetHeld();
        if (isHeld) SetDrop();
        isHeld = !isHeld;
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        holdPosition = FindObjectOfType<ItemHoldPosition>().transform;
    }

    private void Update()
    {
        if (isHeld)
        {
            gameObject.transform.position = holdPosition.position;
        }
    }

    private void SetHeld()
    {
        rigidbody.useGravity = false;
        gameObject.transform.position = holdPosition.position;
        gameObject.transform.SetParent(holdPosition);
    }

    private void SetDrop()
    {
        rigidbody.useGravity = true;
        gameObject.transform.SetParent(null);
    }
}
