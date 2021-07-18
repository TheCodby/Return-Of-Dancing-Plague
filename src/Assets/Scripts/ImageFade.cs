using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    private Image image;
    private float targetAlpha;
    public float moveSpeed = 0.75f;
    private void Start ()
    {
        image = GetComponent<Image>();
        targetAlpha = image.color.a;
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn() {
        yield return new WaitForSeconds(1);
        targetAlpha = 1.0f;
        Color curColor = image.color;
        while(Mathf.Abs(curColor.a - targetAlpha) > 0.0001f) {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, moveSpeed * Time.deltaTime);
            image.color = curColor;
            yield return null;
        }
    }
}
