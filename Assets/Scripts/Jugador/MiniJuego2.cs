using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniJuego2 : MonoBehaviour
{
    public FirsPersonController playerController;
    public ObjectInteraction objectInteraction;
    public ItemHandler itemHandler;

    public RectTransform movingIndicator;
    public RectTransform progressBar;
    public RectTransform[] markers;
    public TextMeshProUGUI buttonText;
    public float indicatorSpeed = 100f;
    private bool isPlaying = false;
    private KeyCode selectedKey;
    private List<KeyCode> possibleKeys = new List<KeyCode> { KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.R, KeyCode.F };

    public GameObject minigameCanvas;
    private int successHits = 0; 
    public int totalMarkers = 3; 

    void Start()
    {
        GenerateMarkers();
        minigameCanvas.SetActive(false);
    }

    void Update()
    {
        if (isPlaying)
        {
            MoveIndicator();

            if (Input.GetKeyDown(selectedKey))
            {
                CheckIfHit();
            }
        }
    }

    public void StartMinigame()
    {
        playerController.enabled = false;
        isPlaying = true;
        successHits = 0;
        SelectRandomKey();
        ResetIndicatorPosition();
        buttonText.text = selectedKey.ToString();
        GenerateMarkers();
        minigameCanvas.SetActive(true);
    }

    private void MoveIndicator()
    {
        RectTransform progressBarRect = progressBar.GetComponent<RectTransform>();

        float progressBarStartX = progressBarRect.rect.xMin;
        float progressBarEndX = progressBarRect.rect.xMax;
        float progressBarWidth = progressBarEndX - progressBarStartX;

        if (movingIndicator.anchoredPosition.x == 0)
        {
            Vector2 startPosition = movingIndicator.anchoredPosition;
            startPosition.x = progressBarStartX;
            movingIndicator.anchoredPosition = startPosition;
        }

        Vector2 newPos = movingIndicator.anchoredPosition;
        newPos.x += indicatorSpeed * Time.deltaTime;

        if (newPos.x >= progressBarEndX)
        {
            ResetIndicatorPosition();
        }
        else
        {
            movingIndicator.anchoredPosition = newPos;
        }
    }

    private void ResetIndicatorPosition()
    {
        Vector2 resetPos = movingIndicator.anchoredPosition;
        resetPos.x = progressBar.GetComponent<RectTransform>().rect.xMin;
        movingIndicator.anchoredPosition = resetPos;
    }

    private void SelectRandomKey()
    {
        selectedKey = possibleKeys[Random.Range(0, possibleKeys.Count)];
    }

    private void CheckIfHit()
    {
        foreach (RectTransform marker in markers)
        {
            if (Mathf.Abs(movingIndicator.anchoredPosition.x - marker.anchoredPosition.x) < 10f)
            {
                successHits++;
                Debug.Log("Acierto!");

                marker.GetComponent<Image>().color = Color.green;

                if (successHits >= totalMarkers)
                {
                    MinigameComplete();
                }
                return;
            }
        }

        Debug.Log("Fallo!");
        RestartMinigame();
    }

    private void GenerateMarkers()
    {
        RectTransform progressBarRect = progressBar.GetComponent<RectTransform>();

        float minDistance = 50f;
        float progressBarStartX = progressBarRect.rect.xMin; 
        float progressBarEndX = progressBarRect.rect.xMax;  

        for (int i = 0; i < markers.Length; i++)
        {
            bool isPositionValid = false;

            while (!isPositionValid)
            {
                float randomX = Random.Range(progressBarStartX, progressBarEndX);
                isPositionValid = true;

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
                    markers[i].anchoredPosition = new Vector2(randomX, markers[i].anchoredPosition.y);
                    markers[i].GetComponent<Image>().color = Color.red;
                }
            }
        }
    }

    private void MinigameComplete()
    {
        playerController.enabled = true;
        objectInteraction.Interacting = false;
        isPlaying = false;
        Debug.Log("Minijuego completado con éxito!");
        minigameCanvas.SetActive(false);

        itemHandler.DiscardItem();
        itemHandler.PickUpTapas();
    }

    private void RestartMinigame()
    {
        isPlaying = false;
        Debug.Log("Minijuego reiniciado.");
        minigameCanvas.SetActive(false);

        StartMinigame();
    }
}
