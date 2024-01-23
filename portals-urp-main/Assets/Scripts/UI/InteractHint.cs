using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHint : MonoBehaviour
{
    public bool isHinting = true;

    [SerializeField] private GameObject hintObj;

    private Transform InteractorSource;
    [SerializeField] private float InteractRange = 4;

    private void Start()
    {
        InteractorSource = FindObjectOfType<PortalCamera>().transform;
    }

    private void Update()
    {
        if (isHinting)
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
    }

    private void ShowHint()
    {
        hintObj.GetComponentInChildren<Transform>().gameObject.SetActive(true);
    }

    private void HideHint()
    {
        hintObj.GetComponentInChildren<Transform>().gameObject.SetActive(false);
    }
}
