using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionDistance = 0.6f;
    public LayerMask interactableLayer;
    public TextMeshProUGUI objectNameText;
    public GameObject interactIcon;
    public bool Interacting = false;

    private Camera playerCamera;
    private ItemHandler itemHandler;

    public bool CarneOnTable = false;
    public bool TapasOnTable = false;
    public bool MesaLista = false;

    void Start()
    {
        playerCamera = Camera.main;
        objectNameText.gameObject.SetActive(false);
        interactIcon.SetActive(false);
        itemHandler = GetComponent<ItemHandler>();
    }

    void Update()
    {
        if (CarneOnTable && TapasOnTable)
        {
            MesaLista = true;
        }

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer) && !Interacting)
        {
            if (hit.collider.CompareTag("Interactuable"))
            {
                objectNameText.text = hit.collider.gameObject.name;
                objectNameText.gameObject.SetActive(true);
                interactIcon.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    InteractWithObject(hit.collider.gameObject);
                }
            }
        }
        else
        {
            objectNameText.gameObject.SetActive(false);
            interactIcon.SetActive(false);
        }
    }

    void InteractWithObject(GameObject interactableObject)
    {
        if (interactableObject.name == "Heladera")
        {
            itemHandler.PickUpCarne();
            return;
        }

        if (interactableObject.name == "Bollos de masa")
        {
            itemHandler.PickUpMasa();
            return;
        }

        if (interactableObject.name == "Basura")
        {
            itemHandler.DiscardItem();
            return;
        }
        
        if (interactableObject.name == "Tabla de cortar" && itemHandler.HasCarne())
        {
            Interacting = true;
            MiniJuego1 miniJuego1 = interactableObject.GetComponent<MiniJuego1>();
            miniJuego1.StartMinigame();
            return;
        }

        if (interactableObject.name == "Tabla de amasar" && itemHandler.HasMasa())
        {
            Interacting = true;
            MiniJuego1 miniJuego1 = interactableObject.GetComponent<MiniJuego1>();
            miniJuego1.StartMinigame();
            return;
        }

        if (interactableObject.name == "Cortadora de masa" && itemHandler.HasPlanchaMasa())
        {
            Interacting = true;
            MiniJuego2 miniJuego2 = interactableObject.GetComponent<MiniJuego2>();
            miniJuego2.StartMinigame();
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.HasCarnePicada() && !CarneOnTable)
        {
            itemHandler.PlaceCarnePicadaOnTable(interactableObject.transform);
            CarneOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.HasTapas() && !TapasOnTable)
        {
            itemHandler.PlaceTapasOnTable(interactableObject.transform);
            TapasOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && MesaLista)
        {
            Interacting = true;
            MiniJuego3 miniJuego3 = interactableObject.GetComponent<MiniJuego3>();
            miniJuego3.StartMinigame();
            return;
        }

        if (interactableObject.name == "Cliente" && itemHandler.HasEmpanadas())
        {
            itemHandler.GiveEmpanadas();
            return;
        }
    }
}
