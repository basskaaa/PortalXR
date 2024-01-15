using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PortalableObject : MonoBehaviour
{
    private GameObject cloneObject;
    [HideInInspector] public GameObject lastPortalTf;
    public float ceilingClippingLenth = 3f;

    private int inPortalCount = 0;
    
    private Portal inPortal;
    private Portal outPortal;

    private new Rigidbody rigidbody;
    protected new Collider collider;

    private static readonly Quaternion halfTurn = Quaternion.Euler(0.0f, 180.0f, 0.0f);

    protected virtual void Awake()
    {
        cloneObject = new GameObject();
        cloneObject.SetActive(false);
        var meshFilter = cloneObject.AddComponent<MeshFilter>();
        var meshRenderer = cloneObject.AddComponent<MeshRenderer>();

        meshFilter.mesh = GetComponent<MeshFilter>().mesh;
        meshRenderer.materials = GetComponent<MeshRenderer>().materials;
        cloneObject.transform.localScale = transform.localScale;

        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void LateUpdate()
    {
        if(inPortal == null || outPortal == null)
        {
            return;
        }

        if(cloneObject.activeSelf && inPortal.IsPlaced && outPortal.IsPlaced)
        {
            var inTransform = inPortal.transform;
            var outTransform = outPortal.transform;

            // Update position of clone.
            Vector3 relativePos = inTransform.InverseTransformPoint(transform.position);
            relativePos = halfTurn * relativePos;
            cloneObject.transform.position = outTransform.TransformPoint(relativePos);

            // Update rotation of clone.
            Quaternion relativeRot = Quaternion.Inverse(inTransform.rotation) * transform.rotation;
            relativeRot = halfTurn * relativeRot;
            cloneObject.transform.rotation = outTransform.rotation * relativeRot;
        }
        else
        {
            cloneObject.transform.position = new Vector3(-1000.0f, 1000.0f, -1000.0f);
        }
    }

    public void SetIsInPortal(Portal inPortal, Portal outPortal, Collider wallCollider)
    {
        this.inPortal = inPortal;
        this.outPortal = outPortal;

        Physics.IgnoreCollision(collider, wallCollider);

        cloneObject.SetActive(false);

        ++inPortalCount;
    }

    public void ExitPortal(Collider wallCollider)
    {
        Physics.IgnoreCollision(collider, wallCollider, false);
        --inPortalCount;

        if (inPortalCount == 0)
        {
            cloneObject.SetActive(false);
        }
    }

    public virtual void Warp()
    {
        var inTransform = inPortal.transform;
        var outTransform = outPortal.transform;
        if (lastPortalTf != null) lastPortalTf.transform.position = outPortal.transform.position;

        // Update position of object.
        Vector3 relativePos = inTransform.InverseTransformPoint(transform.position);
        relativePos = halfTurn * relativePos;
        transform.position = outTransform.TransformPoint(relativePos);

        if (IsPortalOnCeiling())
        {
            //Debug.Log("Ceiling portal");
            transform.position = new Vector3 (transform.position.x, transform.position.y - ceilingClippingLenth, transform.position.z);
        }

        if (FloorToWallPortal())
        {
            WarpFromFloorToWall();
            return;
        }

        // Update rotation of object.
        Quaternion relativeRot = Quaternion.Inverse(inTransform.rotation) * transform.rotation;
        relativeRot = halfTurn * relativeRot;
        transform.rotation = outTransform.rotation * relativeRot;

        // Update velocity of rigidbody.
        Vector3 relativeVel = inTransform.InverseTransformDirection(rigidbody.velocity);
        relativeVel = halfTurn * relativeVel;
        rigidbody.velocity = outTransform.TransformDirection(relativeVel);

        // Swap portal references.
        var tmp = inPortal;
        inPortal = outPortal;
        outPortal = tmp;
    }

    public bool IsPortalOnCeiling()
    {
        if (outPortal.transform.rotation.x < 0)
        {
            return true;
        }
        else return false;
    }

    public bool FloorToWallPortal()
    {
        Debug.Log(inPortal.transform.rotation.x);
        Debug.Log(outPortal.transform.rotation.x);

        if (inPortal.transform.rotation.x > 0 && (outPortal.transform.rotation.x == 0 || outPortal.transform.rotation.x == 1))
        {
            return true;
        }
        else return false;
    }

    public void WarpFromFloorToWall()
    {
        Transform WallPortal = outPortal.gameObject.GetComponentInChildren<PortalExitRotation>().transform;

        // Update rotation of object.
        transform.rotation = WallPortal.rotation;
        //Debug.Log(outTransform.rotation);
        Debug.Log("Exit floor to wall portal");

        // Update velocity of rigidbody.
        float downForce = rigidbody.velocity.magnitude;
        if (rigidbody.velocity.magnitude < 15)
        {
            rigidbody.AddForce(WallPortal.forward * downForce * 300, ForceMode.Force);
        }
        else
        {
            rigidbody.AddForce(WallPortal.forward * downForce * 195, ForceMode.Force);
        }

        // Swap portal references.
        var tmp = inPortal;
        inPortal = outPortal;
        outPortal = tmp;
    }
}
