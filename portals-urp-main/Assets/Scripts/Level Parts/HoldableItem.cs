using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableItem : MonoBehaviour, IInteractable
{
    private Transform holdPosition;
    private Transform turretHoldPosition;
    private Rigidbody rigidbody;

    [HideInInspector] public bool isHeld = false;

    [SerializeField] private bool isTurret;

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
        turretHoldPosition = FindObjectOfType<TurretHoldPos>().transform;
    }

    private void Update()
    {
        if (isHeld)
        {
            if (isTurret) 
            {
                gameObject.transform.position = turretHoldPosition.position;
                return;
            }
            gameObject.transform.position = holdPosition.position;
        }
    }

    private void SetHeld()
    {
        rigidbody.useGravity = false;

        if (isTurret)
        {
            gameObject.transform.SetParent(turretHoldPosition);
            gameObject.transform.position = turretHoldPosition.position;
            gameObject.transform.rotation = turretHoldPosition.rotation;
            rigidbody.freezeRotation = true;
            return;
        }
        gameObject.transform.SetParent(holdPosition);
        gameObject.transform.position = holdPosition.position;
    }

    public void SetDrop()
    {
        if (isTurret)
        {
            rigidbody.freezeRotation = false;
        }
        rigidbody.useGravity = true;
        gameObject.transform.SetParent(null);
    }
}
