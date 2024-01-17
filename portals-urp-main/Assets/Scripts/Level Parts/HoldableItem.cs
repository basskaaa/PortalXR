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

    [SerializeField] private AudioClipHolder[] impactSound;

    public void OnInteract()
    {
        Debug.Log("Interact");
        if (!isHeld) SetHeld();
        if (isHeld && !isTurret) SetDrop();
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
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SetTurretDrop();
                }

                gameObject.transform.position = turretHoldPosition.position;
                gameObject.transform.rotation = turretHoldPosition.rotation;

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
            rigidbody.freezeRotation = true;
            gameObject.transform.rotation = turretHoldPosition.rotation;

            gameObject.GetComponentInChildren<TurretBehaviour>().hasBeenDisplaced = true;
            return;
        }
        gameObject.transform.SetParent(holdPosition);
        gameObject.transform.position = holdPosition.position;
    }

    public void SetDrop()
    {
        rigidbody.useGravity = true;
        gameObject.transform.SetParent(null);
    }

    public void SetTurretDrop()
    {
        rigidbody.freezeRotation = false;
        rigidbody.useGravity = true;
        gameObject.transform.SetParent(null);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int i = Random.Range(0, impactSound.Length);

        AudioManager.Instance.PlaySound(impactSound[i].AudioClip, impactSound[i].Volume);
    }
}
