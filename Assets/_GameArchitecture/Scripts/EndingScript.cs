using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    [SerializeField] GameObject FTB;
    [SerializeField] private int fadeDuration = 1;
    [SerializeField] private Image blackOutScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FadeToBlack();
        }
    }

    public void FadeToBlack()
    {
        FTB.SetActive(true); 
        StartCoroutine(ColorFade(Color.clear, Color.black, fadeDuration));

    }
    IEnumerator ColorFade(Color start, Color end, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;

            blackOutScreen.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
    }
}
