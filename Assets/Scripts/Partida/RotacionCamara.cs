using UnityEngine;

public class RotacionHorizontal : MonoBehaviour
{
    [Header("Configuraci�n de Rotaci�n")]
    [Tooltip("Velocidad de rotaci�n en grados por segundo")]
    public float velocidadRotacion = 10f;

    private void Update()
    {
        // Calcular la rotaci�n por frame
        float rotacionPorFrame = velocidadRotacion * Time.deltaTime;

        // Rotar horizontalmente alrededor del eje Y global
        transform.Rotate(Vector3.up, rotacionPorFrame, Space.World);
    }
}
