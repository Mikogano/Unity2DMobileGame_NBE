using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper2 : MonoBehaviour
{
    // Fade out an audio source over a given duration
    public static IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.volume = 0; // Ensure volume is exactly 0
        audioSource.Stop(); // Stop the audio source after fading out
    }

    // Fade in an audio source over a given duration
    public static IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.volume = 1; // Ensure volume is exactly 1
    }
}
