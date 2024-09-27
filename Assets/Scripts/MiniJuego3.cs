using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniJuego3 : MonoBehaviour
{
    public Button[] arrowButtons; // Los 6 botones en el Canvas
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;

    private List<int> arrowSequence; // Lista que contiene la secuencia de flechas (0 = W, 1 = A, 2 = S, 3 = D)
    private int currentIndex = 0;
    private int correctCount = 0; // Aciertos
    private Dictionary<KeyCode, int> arrowKeyMap = new Dictionary<KeyCode, int>
    {
        { KeyCode.W, 0 },
        { KeyCode.A, 1 },
        { KeyCode.S, 2 },
        { KeyCode.D, 3 }
    };
    private string[] arrowKeys = { "W", "A", "S", "D" }; // Letras para los botones

    public int playerScore = 0; // Para almacenar los aciertos para más tarde

    public FirsPersonController playerController;
    public GameObject minigameCanvas;
    public ObjectInteraction objectInteraction;

    public void StartMinigame()
    {
        minigameCanvas.SetActive(true);
        playerController.enabled = false;

        // Inicializar variables
        arrowSequence = new List<int>();
        currentIndex = 0;
        correctCount = 0;

        // Generar la secuencia de 6 flechas aleatorias
        for (int i = 0; i < 6; i++)
        {
            int randomArrow = Random.Range(0, 4); // 0: W, 1: A, 2: S, 3: D
            arrowSequence.Add(randomArrow);
            arrowButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = arrowKeys[randomArrow]; // Mostrar la tecla en el botón
            arrowButtons[i].GetComponent<Image>().color = Color.white; // Resetear color del botón
        }
    }

    void Update()
    {
        if (arrowSequence != null)
        {
            // Revisar si ya se completó la secuencia
            if (currentIndex >= arrowSequence.Count)
                return;

            // Verificar entrada del jugador
            foreach (KeyCode key in arrowKeyMap.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    CheckArrowInput(arrowKeyMap[key]);
                    break;
                }
            }
        }
    }

    void CheckArrowInput(int playerInput)
    {
        // Verificar si el input es correcto
        if (playerInput == arrowSequence[currentIndex])
        {
            arrowButtons[currentIndex].GetComponent<Image>().color = correctColor; // Cambiar a verde si es correcto
            correctCount++; // Aumentar el contador de correctas
        }
        else
        {
            arrowButtons[currentIndex].GetComponent<Image>().color = incorrectColor; // Cambiar a rojo si es incorrecto
        }

        currentIndex++;

        // Si se ha llegado al final de la secuencia, almacenar los aciertos
        if (currentIndex >= arrowSequence.Count)
        {
            EndMinigame();
        }
    }

    void EndMinigame()
    {
        // Guardar los aciertos en una variable para usarlos más tarde
        playerScore = correctCount;

        playerController.enabled = true;
        objectInteraction.Interacting = false;
        minigameCanvas.SetActive(false);
    }
}
