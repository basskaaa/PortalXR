using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHint : MonoBehaviour
{
    [SerializeField] private GameObject hintObj;

    private Transform InteractorSource;
    private float InteractRange = 5;

    private void Start()
    {
        InteractorSource = FindObjectOfType<PortalCamera>().transform;
        hintObj = FindObjectOfType<InteractHintUi>().gameObject; 
        HideHint();
    }

    private void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                ShowHint();
            }
        }

        else
        {
            HideHint();
        }
    }

    private void ShowHint()
    {
        hintObj.SetActive(true);
    }

    private void HideHint()
    {
        hintObj.SetActive(false);
    }
}
