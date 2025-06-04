using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgDamageUI_img : MonoBehaviour
{
    public Image bgDamage {  get; private set; }
    public CanvasGroup canvasGroup { get; private set; }
    private void Awake()
    {
        bgDamage = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void ThresholdAlphaImage(bool hasLowHP)
    {
        canvasGroup.alpha = hasLowHP ? 1 : 0;
    }
}
