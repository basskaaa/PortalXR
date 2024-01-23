using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementUiHint : MonoBehaviour
{
    private Image[] images;

    private void Start()
    {
        images = GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            image.enabled = true;
            image.DOFade(0, 7f);
        }
    }
}
