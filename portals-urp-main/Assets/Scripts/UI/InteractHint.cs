using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractHint : MonoBehaviour
{
    public bool isHinting = true;

    [SerializeField] private Image hintText;
    private float hintOpacity = 1f;
    private float buttonHintOpacity = 1f;

    private Transform InteractorSource;
    [SerializeField] private float InteractRange = 4;

    private void Start()
    {
        InteractorSource = FindObjectOfType<PortalCamera>().transform;
        hintText.enabled = true;
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

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hintOpacity = hintOpacity - 0.1f;
                    }

                    if (hitInfo.transform.gameObject.GetComponent<InteractableButton>() != null)
                    {
                        IButtonHint();
                    }
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
        hintText.DOFade(hintOpacity, 0f);
    }

    private void HideHint()
    {
        hintText.DOFade(0, 0.0f);
    }

    private void IButtonHint()
    {
        hintText.DOFade(buttonHintOpacity, 5f);
        buttonHintOpacity = buttonHintOpacity - 0.5f;
    }
}
