using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    private FirstPersonController controller;
    private PortalPlacement portalContoller;
    private Interactor interactor;

    private void Start()
    {
        controller = GetComponent<FirstPersonController>();
        portalContoller = GetComponentInChildren<PortalPlacement>();
        interactor = GetComponentInChildren<Interactor>();
    }

    public void StopPlayerControls()
    {
        controller.playerCanMove = false;
        controller.cameraCanMove = false;
        controller.enableJump = false;
        controller.enableCrouch = false;
        portalContoller.canPlacePortals = false;
        interactor.canInteract = false;
    }

    public void StartPlayerControls()
    {
        controller.playerCanMove = true;
        controller.cameraCanMove = true;
        controller.enableJump = true;
        controller.enableCrouch = true;
        portalContoller.canPlacePortals = true;
        interactor.canInteract = true;
    }
}
