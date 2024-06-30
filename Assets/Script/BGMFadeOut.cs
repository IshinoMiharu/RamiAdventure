using UnityEngine;
using System.Collections;

public class BGMFadeOut : MonoBehaviour
{
    public AudioSource bgmSource;  // �t�F�[�h�A�E�g������BGM��AudioSource
    public float fadeDuration = 1.0f;  // �t�F�[�h�A�E�g�̎���

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
