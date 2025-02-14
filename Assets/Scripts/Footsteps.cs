using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour
{
    private AudioSource audioSource; // Referencia al AudioSource
    private float targetVolume = 1.0f;
    public float fadeDuration = 4f; // Tiempo en segundos para alcanzar el volumen máximo

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FadeInVolume(audioSource, fadeDuration, targetVolume));
    }
    

    private IEnumerator FadeInVolume(AudioSource source, float duration, float maxVolume)
    {
        float elapsedTime = 0f;

        source.volume = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;

            // Curva de crecimiento exponencial
            source.volume = maxVolume * Mathf.Pow(progress, 2);

            yield return null;
        }

        source.volume = maxVolume; // Aseguramos que el volumen llegue exactamente al máximo
    }
}
