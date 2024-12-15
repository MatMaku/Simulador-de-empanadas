using UnityEngine;

public class RotacionHorizontal : MonoBehaviour
{
    [Header("Configuración de Rotación")]
    [Tooltip("Velocidad de rotación en grados por segundo")]
    public float velocidadRotacion = 10f;

    private void Update()
    {
        // Calcular la rotación por frame
        float rotacionPorFrame = velocidadRotacion * Time.deltaTime;

        // Rotar horizontalmente alrededor del eje Y global
        transform.Rotate(Vector3.up, rotacionPorFrame, Space.World);
    }
}
