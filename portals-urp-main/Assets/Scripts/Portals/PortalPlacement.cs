﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraMove))]
public class PortalPlacement : MonoBehaviour
{
    [SerializeField]
    private PortalPair portals;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Crosshair crosshair;

    private CameraMove cameraMove;

    public bool canPlacePortals;
    private bool inPortalActive;
    private bool outPortalActive;

    [SerializeField] private AudioClipHolder orangePortalSound;
    [SerializeField] private AudioClipHolder bluePortalSound;

    private void Awake()
    {
        cameraMove = GetComponent<CameraMove>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && canPlacePortals)
        {
            FirePortal(0, transform.position, transform.forward, 250.0f);
            AudioManager.Instance.PlaySound(bluePortalSound.AudioClip, bluePortalSound.Volume);

        }
        else if (Input.GetButtonDown("Fire2") && canPlacePortals)
        {
            FirePortal(1, transform.position, transform.forward, 250.0f);
            AudioManager.Instance.PlaySound(orangePortalSound.AudioClip, orangePortalSound.Volume);
        }
    }

    private void FirePortal(int portalID, Vector3 pos, Vector3 dir, float distance)
    {
        RaycastHit hit;
        Physics.Raycast(pos, dir, out hit, distance, layerMask);

        if(hit.collider != null)
        {
            // If we shoot a portal, recursively fire through the portal.
            if (hit.collider.tag == "Portal")
            {
                var inPortal = hit.collider.GetComponent<Portal>();

                if(inPortal == null)
                {
                    return;
                }

                var outPortal = inPortal.OtherPortal;

                // Update position of raycast origin with small offset.
                Vector3 relativePos = inPortal.transform.InverseTransformPoint(hit.point + dir);
                relativePos = Quaternion.Euler(0.0f, 180.0f, 0.0f) * relativePos;
                pos = outPortal.transform.TransformPoint(relativePos);

                // Update direction of raycast.
                Vector3 relativeDir = inPortal.transform.InverseTransformDirection(dir);
                relativeDir = Quaternion.Euler(0.0f, 180.0f, 0.0f) * relativeDir;
                dir = outPortal.transform.TransformDirection(relativeDir);

                distance -= Vector3.Distance(pos, hit.point);

                FirePortal(portalID, pos, dir, distance);

                return;
            }

            // Orient the portal according to camera look direction and surface direction.
            var cameraRotation = cameraMove.TargetRotation;
            var portalRight = cameraRotation * Vector3.right;
            
            if(Mathf.Abs(portalRight.x) >= Mathf.Abs(portalRight.z))
            {
                portalRight = (portalRight.x >= 0) ? Vector3.right : -Vector3.right;
            }
            else
            {
                portalRight = (portalRight.z >= 0) ? Vector3.forward : -Vector3.forward;
            }

            var portalForward = -hit.normal;
            var portalUp = -Vector3.Cross(portalRight, portalForward);

            var portalRotation = Quaternion.LookRotation(portalForward, portalUp);
            
            // Attempt to place the portal.
            bool wasPlaced = portals.Portals[portalID].PlacePortal(hit.collider, hit.point, portalRotation);

            if(wasPlaced)
            {
                crosshair.SetPortalPlaced(portalID, true);
                CheckActivePortals(portalID);
            }
        }
    }

    private void CheckActivePortals(int portalID)
    { 
        if (portalID == 0)
        {
            inPortalActive = true;
        }
        if (portalID == 1)
        {
            outPortalActive = true;
        }
        if (inPortalActive &&  outPortalActive)
        {
            GameManager.Instance.bothPortalsActive = true;
        }
    }
}
