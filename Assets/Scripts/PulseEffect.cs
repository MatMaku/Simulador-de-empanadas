using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseEffect : MonoBehaviour
{
    public RectTransform iconTransform; // Referencia al RectTransform del icono de la tecla E
    public float pulseDuration = 0.5f; // Duración del pulso
    public float pulseScale = 1.2f; // Tamaño máximo durante el pulso

    private Vector3 originalScale;
    private Coroutine pulseCoroutine;

    void Start()
    {
        originalScale = iconTransform.localScale;
    }

    // Llamar esta función cuando quieras iniciar el efecto de latido
    public void StartPulse()
    {
        // Si ya hay una corutina en marcha, detenerla
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
        }
        // Iniciar la corutina de nuevo
        pulseCoroutine = StartCoroutine(PulseIcon());
    }

    // Llamar esta función para detener el efecto de latido
    public void StopPulse()
    {
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
        }
        // Restaurar la escala original del icono
        iconTransform.localScale = originalScale;
    }

    IEnumerator PulseIcon()
    {
        while (true) // Loop infinito para que el latido continúe
        {
            yield return ScaleTo(pulseScale); // Agrandar el ícono
            yield return ScaleTo(originalScale.x); // Reducir el ícono al tamaño original
        }
    }

    IEnumerator ScaleTo(float targetScale)
    {
        float time = 0f;
        Vector3 startScale = iconTransform.localScale;
        Vector3 endScale = originalScale * targetScale;

        while (time < pulseDuration)
        {
            time += Time.deltaTime;
            iconTransform.localScale = Vector3.Lerp(startScale, endScale, time / pulseDuration);
            yield return null;
        }

        iconTransform.localScale = endScale;
    }
}
