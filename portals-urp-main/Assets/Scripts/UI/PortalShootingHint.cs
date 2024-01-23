using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalShootingHint : MonoBehaviour
{
    [SerializeField] Image blue;
    [SerializeField] Image lClick;
    [SerializeField] Image orange;
    [SerializeField] Image rClick;

    bool active = false;

    private void Start()
    {
        blue.enabled = false;
        lClick.enabled = false;
        orange.enabled = false;
        rClick.enabled = false;
    }

    public void SetActive()
    {
        blue.enabled = true;
        lClick.enabled = true;
        orange.enabled = true;
        rClick.enabled = true;
        active = true;
    }

    private void Update()
    {
        if (active) 
        { 
            if (Input.GetKeyUp(KeyCode.Mouse0)) 
            {
                blue.DOFade(0, 5f);
                lClick.DOFade(0, 5f);
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                orange.DOFade(0, 5f);
                rClick.DOFade(0, 5f);
            }
        }
    }
}
