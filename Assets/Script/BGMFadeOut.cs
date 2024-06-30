using UnityEngine;
using System.Collections;

public class BGMFadeOut : MonoBehaviour
{
    public AudioSource bgmSource;  // フェードアウトさせるBGMのAudioSource
    public float fadeDuration = 1.0f;  // フェードアウトの時間

    private bool isFading = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            StartCoroutine(FadeOutBGM());
        }
    }

    IEnumerator FadeOutBGM()
    {
        isFading = true;
        float startVolume = bgmSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        bgmSource.volume = 0;
        bgmSource.Stop();
        isFading = false;
    }
}
