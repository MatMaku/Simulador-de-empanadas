using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionDistance = .6f; // Distancia máxima para interactuar
    public LayerMask interactableLayer; // Capas a las que pertenecen los objetos interactivos
    public TextMeshProUGUI objectNameText; // UI para mostrar el nombre del objeto
    public GameObject interactIcon; // Icono de la tecla "E"
    public bool Interacting = false;

    private Camera playerCamera;
    private FirsPersonController firsPersonController;

    void Start()
    {
        firsPersonController = GetComponent<FirsPersonController>();
        playerCamera = Camera.main;
        objectNameText.gameObject.SetActive(false);
        interactIcon.SetActive(false);
    }

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        // Detectar si el raycast impacta en un objeto interactivo
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer) && !Interacting)
        {
            if (hit.collider.CompareTag("Interactuable"))
            {
                // Mostrar nombre del objeto y el ícono de "E"
                objectNameText.text = hit.collider.gameObject.name; // Asumimos que el nombre del objeto es su nombre en la escena
                objectNameText.gameObject.SetActive(true);
                interactIcon.SetActive(true);

                // Si el jugador presiona "E", llamamos al método de interacción
                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractWithObject(hit.collider.gameObject);
                }
            }
        }
        else
        {
            // Ocultar los indicadores si no hay ningún objeto interactivo en el centro de la cámara
            objectNameText.gameObject.SetActive(false);
            interactIcon.SetActive(false);
        }
    }

    void InteractWithObject(GameObject interactableObject)
    {
        Interacting = true;

        MiniJuego1 miniJuego1 = interactableObject.GetComponent<MiniJuego1>();
        if (miniJuego1 != null)
        {
            miniJuego1.StartCuttingMinigame();
            return;
        }

        MiniJuego2 miniJuego2 = interactableObject.GetComponent<MiniJuego2>();
        if (miniJuego2 != null)
        {
            miniJuego2.StartMinigame();
            return;
        }

        MiniJuego3 miniJuego3 = interactableObject.GetComponent<MiniJuego3>();
        if (miniJuego3 != null)
        {
            miniJuego3.StartMinigame();
            return;
        }
    }
}
