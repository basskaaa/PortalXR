using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeIn : MonoBehaviour
{
    RawImage startLevelMask;

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
        yield return new WaitForSeconds(4f);
        startLevelMask.DOFade(0, 6f);
    }
}
