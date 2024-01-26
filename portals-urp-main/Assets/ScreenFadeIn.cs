using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeIn : MonoBehaviour
{
    RawImage startLevelMask;
    public Image aperture;

    private void Start()
    {
        startLevelMask = GetComponent<RawImage>();
        startLevelMask.DOFade(1, 0f);
        startLevelMask.DOFade(0, 6f);
    }

    public void StartFadeInOut()
    {
        StartCoroutine(FadeInFadeOut());
    }

    private IEnumerator FadeInFadeOut()
    {
        startLevelMask.DOFade(1, 3f);
        aperture.DOFade(0.3f, 3f);
        yield return new WaitForSeconds(4f);
        startLevelMask.DOFade(0, 6f);
        aperture.DOFade(0, 1f);
    }
}
