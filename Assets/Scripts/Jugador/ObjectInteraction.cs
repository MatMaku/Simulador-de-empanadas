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
    public GameObject discardIcon;
    public bool Interacting = false;

    private Camera playerCamera;
    private ItemHandler itemHandler;

    public bool CarneOnTable = false;
    public bool TapasOnTable = false;
    public bool JamonOnTable = false;
    public bool QuesoOnTable = false;
    public bool JyQOnTable = false;
    public bool PlanchaOnTable = false;
    public bool MesaEmpanadaCarneLista = false;
    public bool MesaJyQLista = false;
    public bool MesaEmpanadaJyQLista = false;
    public bool MesaPizzaLista = false;

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
            MesaEmpanadaCarneLista = true;
        }

        if (JamonOnTable && QuesoOnTable)
        {
            MesaJyQLista = true;
        }

        if (JyQOnTable && TapasOnTable)
        {
            MesaEmpanadaJyQLista = true;
        }

        if (QuesoOnTable && PlanchaOnTable)
        {
            MesaPizzaLista = true;
        }

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer) && !Interacting)
        {
            if (hit.collider.CompareTag("Interactuable"))
            {
                if (hit.collider.gameObject.name == "Cliente(Clone)" || hit.collider.gameObject.name == "Cliente tutorial")
                {
                    objectNameText.text = "Cliente";
                    objectNameText.gameObject.SetActive(true);
                    interactIcon.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "Mesa de preparado")
                {
                    objectNameText.text = hit.collider.gameObject.name;
                    objectNameText.gameObject.SetActive(true);
                    interactIcon.SetActive(true);
                    discardIcon.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        DiscardTable(hit.collider.gameObject);
                    }
                }
                else
                {
                    objectNameText.text = hit.collider.gameObject.name;
                    objectNameText.gameObject.SetActive(true);
                    interactIcon.SetActive(true);
                }

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
            discardIcon.SetActive(false);
        }
    }

    void DiscardTable(GameObject Object)
    {
        foreach (Transform child in Object.transform)
        {
            Destroy(child.gameObject);

            CarneOnTable = false;
            TapasOnTable = false;
            JamonOnTable = false;
            QuesoOnTable = false;
            PlanchaOnTable = false; 
            MesaEmpanadaCarneLista = false;
            MesaJyQLista = false;
            MesaEmpanadaJyQLista = false;
            MesaPizzaLista = false;
        }
    }

    void InteractWithObject(GameObject interactableObject)
    {
        if (interactableObject.name == "Jamon")
        {
            itemHandler.PickUpJamon();
            return;
        }

        if (interactableObject.name == "Queso")
        {
            itemHandler.PickUpQueso();
            return;
        }

        if (interactableObject.name == "Carne")
        {
            itemHandler.PickUpCarne();
            return;
        }

        if (interactableObject.name == "Masa")
        {
            itemHandler.PickUpMasa();
            return;
        }

        if (interactableObject.name == "Bebida")
        {
            itemHandler.PickUpBebida();
            return;
        }

        if (interactableObject.name == "Basura")
        {
            itemHandler.DiscardItem();
            return;
        }
        
        if (interactableObject.name == "Tabla de cortar" && itemHandler.hasCarne)
        {
            Interacting = true;
            MiniJuego1 miniJuego1 = interactableObject.GetComponent<MiniJuego1>();
            miniJuego1.StartMinigame();
            return;
        }

        if (interactableObject.name == "Tabla de amasar" && itemHandler.hasMasa)
        {
            Interacting = true;
            MiniJuego1 miniJuego1 = interactableObject.GetComponent<MiniJuego1>();
            miniJuego1.StartMinigame();
            return;
        }

        if (interactableObject.name == "Cortadora de masa" && itemHandler.hasPlanchaMasa)
        {
            Interacting = true;
            MiniJuego2 miniJuego2 = interactableObject.GetComponent<MiniJuego2>();
            miniJuego2.StartMinigame();
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.hasCarnePicada && !CarneOnTable && !QuesoOnTable && !JyQOnTable)
        {
            itemHandler.PlaceCarnePicadaOnTable(interactableObject.transform);
            CarneOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.hasTapas && !TapasOnTable && !PlanchaOnTable && !JamonOnTable)
        {
            itemHandler.PlaceTapasOnTable(interactableObject.transform);
            TapasOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && MesaEmpanadaCarneLista && itemHandler.HasEspacio())
        {
            Interacting = true;
            MiniJuego3 miniJuego3 = interactableObject.GetComponent<MiniJuego3>();
            miniJuego3.StartMinigame(0);
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.hasJamon && !JamonOnTable && !PlanchaOnTable && !TapasOnTable)
        {
            itemHandler.PlaceJamonOnTable(interactableObject.transform);
            JamonOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.hasQueso && !QuesoOnTable && !CarneOnTable && !JyQOnTable)
        {
            itemHandler.PlaceQuesoOnTable(interactableObject.transform);
            QuesoOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && MesaJyQLista && itemHandler.HasEspacio())
        {
            Interacting = true;
            MiniJuego3 miniJuego3 = interactableObject.GetComponent<MiniJuego3>();
            miniJuego3.StartMinigame(1);
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.hasJyQ && !JyQOnTable && !CarneOnTable && !QuesoOnTable)
        {
            itemHandler.PlaceJyQOnTable(interactableObject.transform);
            JyQOnTable = true;
            return;
        }


        if (interactableObject.name == "Mesa de preparado" && MesaEmpanadaJyQLista && itemHandler.HasEspacio())
        {
            Interacting = true;
            MiniJuego3 miniJuego3 = interactableObject.GetComponent<MiniJuego3>();
            miniJuego3.StartMinigame(2);
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && itemHandler.hasPlanchaMasa && !PlanchaOnTable && !JamonOnTable && !TapasOnTable)
        {
            itemHandler.PlaceMasaOnTable(interactableObject.transform);
            PlanchaOnTable = true;
            return;
        }

        if (interactableObject.name == "Mesa de preparado" && MesaPizzaLista && itemHandler.HasEspacio())
        {
            Interacting = true;
            MiniJuego3 miniJuego3 = interactableObject.GetComponent<MiniJuego3>();
            miniJuego3.StartMinigame(3);
            return;
        }

        if (interactableObject.name == "Horno")
        {
            HornoInteraction hornoInteraction = interactableObject.GetComponent<HornoInteraction>();
            hornoInteraction.Interact();
            return;
        }

        if (interactableObject.name == "Mesa")
        {
            MesaInteraction mesaInteraction = interactableObject.GetComponent<MesaInteraction>();
            mesaInteraction.Interact();
            return;
        }

        if (interactableObject.name == "Cliente tutorial")
        {
            ClienteTutorial cliente = interactableObject.GetComponent<ClienteTutorial>();

            if (itemHandler.hasEmpanadasCarne)
            {
                cliente.RecibirEmpanada();
                itemHandler.GiveEmpanadasCarne();

                return;
            }
        }

        if (interactableObject.name == "Cliente(Clone)")
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            Cliente cliente = interactableObject.GetComponent<Cliente>();

            // Verifica si tienes empanadas de carne para entregar
            if (itemHandler.hasEmpanadasCarne)
            {
                bool empanadaEntregada = gameManager.EntregarItemAlCliente("empanada", itemHandler.EmpanadasCarneInstance.GetComponent<ValorEmpanadas>().Valor);

                // Solo elimina la empanada si el cliente la aceptó
                if (empanadaEntregada)
                {
                    itemHandler.GiveEmpanadasCarne(); // Actualiza el inventario de empanadas en el itemHandler
                }
                return;
            }

            // Verifica si tienes empanadas de JyQ para entregar
            if (itemHandler.hasEmpanadasJyQ)
            {
                bool empanadaJyQEntregada = gameManager.EntregarItemAlCliente("empanadaJyQ", itemHandler.EmpanadasJyQInstance.GetComponent<ValorEmpanadas>().Valor);

                // Solo elimina la empanada si el cliente la aceptó
                if (empanadaJyQEntregada)
                {
                    itemHandler.GiveEmpanadasJyQ(); // Actualiza el inventario de empanadas en el itemHandler
                }
                return;
            }

            // Verifica si tienes pizza para entregar
            if (itemHandler.hasPizza)
            {
                bool pizzaEntregada = gameManager.EntregarItemAlCliente("pizza", itemHandler.PizzaInstance.GetComponent<ValorEmpanadas>().Valor);

                // Solo elimina la pizza si el cliente la aceptó
                if (pizzaEntregada)
                {
                    itemHandler.GivePizza(); // Actualiza el inventario de pizzas en el itemHandler
                }
                return;
            }

            // Verifica si tienes bebidas para entregar
            if (itemHandler.hasBebida)
            {
                bool bebidaEntregada = gameManager.EntregarItemAlCliente("bebida", 10);

                // Solo elimina la bebida si el cliente la aceptó
                if (bebidaEntregada)
                {
                    itemHandler.GiveBebidas(); // Actualiza el inventario de bebidas en el itemHandler
                }
                return;
            }
        }
    }
}
