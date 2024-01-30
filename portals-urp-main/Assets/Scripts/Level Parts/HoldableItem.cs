using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableItem : MonoBehaviour, IInteractable
{
    private Transform holdPosition;
    private Transform turretHoldPosition;
    private Rigidbody rb;
    private Collider itemCollider;

    public bool isHeld = false;

    public bool isTurret;
    public bool isBox;

    [SerializeField] private AudioClipHolder[] impactSound;
    [SerializeField] private GameEvent boxPickedUp;
    private bool eventRasied = false;
    private bool firstFall = false;

    private Transform _oldParent;
    public Portal[] portals;


    public void OnInteract()
    {
        //Debug.Log("Interact");
        if (!isHeld) SetHeld();
        if (!isHeld && isBox && !eventRasied)
        {
            boxPickedUp.Raise();
            eventRasied = true;
        }
        if (isHeld && !isTurret) SetDrop();
        isHeld = !isHeld;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        itemCollider = GetComponent<Collider>();
        holdPosition = FindObjectOfType<ItemHoldPosition>().transform;
        turretHoldPosition = FindObjectOfType<TurretHoldPos>().transform;
        portals = FindObjectsByType<Portal>(FindObjectsSortMode.InstanceID);
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
            Physics.IgnoreLayerCollision(7, 8, true);
        }

        else
        {
            Physics.IgnoreLayerCollision(7, 8, false);
        }
    }

    private void SetHeld()
    {
        rb.useGravity = false;

        if (isTurret)
        {
            gameObject.transform.SetParent(turretHoldPosition);
            gameObject.transform.position = turretHoldPosition.position;
            rb.freezeRotation = true;
            gameObject.transform.rotation = turretHoldPosition.rotation;

            gameObject.GetComponentInChildren<TurretBehaviour>().isDisplaced = true;
            return;
        }

        _oldParent = gameObject.transform.parent;
        gameObject.transform.SetParent(holdPosition);
        gameObject.transform.position = holdPosition.position;
    }

    public void SetDrop()
    {
        rb.useGravity = true;
        if (_oldParent != null)
        {
            gameObject.transform.SetParent(_oldParent);
            return;
        }
        gameObject.transform.SetParent(null);
    }

    public void SetTurretDrop()
    {
        rb.freezeRotation = false;
        rb.useGravity = true;
        gameObject.transform.SetParent(null);
        gameObject.GetComponentInChildren<TurretBehaviour>().isDisplaced = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (firstFall)
        {
            int i = Random.Range(0, impactSound.Length);

            AudioManager.Instance.PlaySound(impactSound[i].AudioClip, impactSound[i].Volume);
        }
        else
        {
            firstFall = true;
        }
    }

    public void DestroyHoldable()
    {
        Destroy(gameObject, 0.5f);
        //SetDrop();
        //itemCollider.enabled = false;
        //if (portals != null)
        //{
        //    if (portals[0] == null && portals[1] == null)
        //    {
        //        Debug.Log("Warning");
        //        gameObject.SetActive(false);
        //        return;
        //    }
        //    if (portals[0] != null && portals[0].portalObjects.Contains(gameObject.GetComponent<PortalableObject>()))
        //    {
        //        portals[0].portalObjects.Remove(gameObject.GetComponent<PortalableObject>());
        //    }
        //    if (portals[1] != null && portals[1].portalObjects.Contains(gameObject.GetComponent<PortalableObject>()))
        //    {
        //        portals[1].portalObjects.Remove(gameObject.GetComponent<PortalableObject>());
        //    }
        //}
        //else
        //{
        //}
    }
}
