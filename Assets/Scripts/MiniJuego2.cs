using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniJuego2 : MonoBehaviour
{
    public FirsPersonController playerController;
    public ObjectInteraction objectInteraction;
    public RectTransform movingIndicator; // Indicador móvil
    public RectTransform progressBar; // Barra de progreso
    public RectTransform[] markers; // Marcadores (los indicadores fijos)
    public TextMeshProUGUI buttonText; // Texto que muestra la tecla seleccionada
    public float indicatorSpeed = 100f; // Velocidad del indicador móvil
    private bool isPlaying = false;
    private KeyCode selectedKey;
    private List<KeyCode> possibleKeys = new List<KeyCode> { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.R, KeyCode.F };

    public GameObject minigameCanvas; // Canvas o panel de UI del minijuego
    private int successHits = 0; // Número de marcadores acertados
    public int totalMarkers = 3; // Total de marcadores

    void Start()
    {
        GenerateMarkers(); // Genera los marcadores al iniciar el minijuego
        minigameCanvas.SetActive(false); // Asegúrate de que los elementos de UI están ocultos al inicio
    }

    void Update()
    {
        if (isPlaying)
        {
            MoveIndicator();

            // Comprobar si el jugador presiona la tecla correcta
            if (Input.GetKeyDown(selectedKey))
            {
                CheckIfHit();
            }
        }
    }

    // Iniciar el minijuego
    public void StartMinigame()
    {
        playerController.enabled = false;
        isPlaying = true;
        successHits = 0;
        SelectRandomKey();
        ResetIndicatorPosition();
        buttonText.text = selectedKey.ToString();
        GenerateMarkers(); // Colocar marcadores al iniciar el minijuego
        minigameCanvas.SetActive(true); // Mostrar los elementos del Canvas
    }

    // Mover el indicador de izquierda a derecha
    private void MoveIndicator()
    {
        // Obtener el RectTransform de la barra de progreso
        RectTransform progressBarRect = progressBar.GetComponent<RectTransform>();

        // Obtener el tamaño y posición locales de la barra
        float progressBarStartX = progressBarRect.rect.xMin;  // Inicio de la barra en coordenadas locales
        float progressBarEndX = progressBarRect.rect.xMax;    // Fin de la barra en coordenadas locales
        float progressBarWidth = progressBarEndX - progressBarStartX;

        // Inicializar el movingIndicator en la posición inicial de la barra
        if (movingIndicator.anchoredPosition.x == 0)
        {
            Vector2 startPosition = movingIndicator.anchoredPosition;
            startPosition.x = progressBarStartX;  // Posición inicial en el borde izquierdo
            movingIndicator.anchoredPosition = startPosition;
        }

        // Mover el indicador en base a la velocidad dentro de las coordenadas locales
        Vector2 newPos = movingIndicator.anchoredPosition;
        newPos.x += indicatorSpeed * Time.deltaTime;

        // Limitar el movimiento del indicador a los límites de la barra
        if (newPos.x >= progressBarEndX)
        {
            ResetIndicatorPosition();  // Reinicia la posición al comienzo
        }
        else
        {
            movingIndicator.anchoredPosition = newPos;
        }
    }

    // Restablecer la posición del indicador móvil al inicio de la barra
    private void ResetIndicatorPosition()
    {
        // Reiniciar la posición del indicador al borde izquierdo de la barra
        Vector2 resetPos = movingIndicator.anchoredPosition;
        resetPos.x = progressBar.GetComponent<RectTransform>().rect.xMin;
        movingIndicator.anchoredPosition = resetPos;
    }

    // Selecciona una tecla aleatoria
    private void SelectRandomKey()
    {
        selectedKey = possibleKeys[Random.Range(0, possibleKeys.Count)];
    }

    // Comprobar si el indicador móvil está sobre un marcador
    private void CheckIfHit()
    {
        foreach (RectTransform marker in markers)
        {
            // Comprobar si el indicador móvil está cerca de un marcador
            if (Mathf.Abs(movingIndicator.anchoredPosition.x - marker.anchoredPosition.x) < 10f)
            {
                successHits++;
                Debug.Log("Acierto!");

                // Cambiar el color del marcador a verde para indicar que fue acertado
                marker.GetComponent<Image>().color = Color.green;

                if (successHits >= totalMarkers)
                {
                    MinigameComplete();
                }
                return;
            }
        }

        // Si fallas
        Debug.Log("Fallo!");
        RestartMinigame();
    }

    // Generar los marcadores en posiciones aleatorias
    private void GenerateMarkers()
    {
        // Obtener el RectTransform de la barra de progreso
        RectTransform progressBarRect = progressBar.GetComponent<RectTransform>();

        float minDistance = 50f; // Distancia mínima entre marcadores

        // Obtener los límites en coordenadas locales
        float progressBarStartX = progressBarRect.rect.xMin;  // Inicio de la barra en coordenadas locales
        float progressBarEndX = progressBarRect.rect.xMax;    // Fin de la barra en coordenadas locales

        for (int i = 0; i < markers.Length; i++)
        {
            bool isPositionValid = false;

            while (!isPositionValid)
            {
                // Generar posición aleatoria dentro de los límites de la barra
                float randomX = Random.Range(progressBarStartX, progressBarEndX);
                isPositionValid = true;

                // Verificar la distancia entre este marcador y los anteriores
                for (int j = 0; j < i; j++)
                {
                    if (Mathf.Abs(randomX - markers[j].anchoredPosition.x) < minDistance)
                    {
                        isPositionValid = false;
                        break;
                    }
                }

                if (isPositionValid)
                {
                    // Asignar la posición dentro de la barra de progreso en coordenadas locales
                    markers[i].anchoredPosition = new Vector2(randomX, markers[i].anchoredPosition.y);
                    markers[i].GetComponent<Image>().color = Color.red;
                }
            }
        }
    }

    // Completar el minijuego
    private void MinigameComplete()
    {
        playerController.enabled = true;
        objectInteraction.Interacting = false;
        isPlaying = false;
        Debug.Log("Minijuego completado con éxito!");
        minigameCanvas.SetActive(false); // Ocultar el Canvas al completar el minijuego
    }

    // Reiniciar el minijuego si el jugador falla
    private void RestartMinigame()
    {
        isPlaying = false;
        Debug.Log("Minijuego reiniciado.");
        minigameCanvas.SetActive(false); // Ocultar el Canvas al fallar

        StartMinigame();
    }
}
