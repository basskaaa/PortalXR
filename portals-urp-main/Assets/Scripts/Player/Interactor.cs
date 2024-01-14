using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void OnInteract();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) 
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)) 
                { 
                    interactObj.OnInteract();
                }
            }
        }
    }
}
