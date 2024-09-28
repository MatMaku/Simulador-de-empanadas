using System.Collections;
using TMPro;
using UnityEngine;

public class HornoInteraction : MonoBehaviour
{
    public Transform hornoPosition;
    public GameObject empanadaCocinadaPrefab;
    public TextMeshPro cookTimeText; // El texto sobre el horno
    private GameObject empanadaCruda;
    private GameObject empanadaCocinada;
    private bool cooking = false;
    private bool empanadaListo = false;
    private float cookTime = 10f;
    private float remainingTime;

    private ItemHandler itemHandler;

    void Start()
    {
        itemHandler = FindObjectOfType<ItemHandler>(); // Para obtener el manejador de items
        cookTimeText.gameObject.SetActive(false); // Desactivar el texto al inicio
    }

    void Update()
    {
        if (cooking)
        {
            remainingTime -= Time.deltaTime;
            cookTimeText.text = "Cocinando: " + Mathf.Ceil(remainingTime).ToString() + "s";

            if (remainingTime <= 0f)
            {
                FinishCooking();
            }
        }
    }

    public void Interact()
    {
        if (!cooking && itemHandler.hasEmpanadasCrudas) // Verifica si el jugador tiene empanada cruda
        {
            StartCooking();
        }
        else if (empanadaListo && itemHandler.HasEspacio()) // Si la empanada está lista y el jugador tiene espacio
        {
            GiveCookedEmpanada();
        }
    }

    private void StartCooking()
    {
        cooking = true;
        remainingTime = cookTime;

        empanadaCruda = itemHandler.EmpanadasCrudasInstance; // Obtener la empanada cruda
        empanadaCruda.transform.SetParent(hornoPosition);
        empanadaCruda.transform.localPosition = Vector3.zero;

        itemHandler.EmpanadasCrudasInstance = null;
        itemHandler.hasEmpanadasCrudas = false;

        cookTimeText.gameObject.SetActive(true); // Mostrar el texto de cocción
    }

    private void FinishCooking()
    {
        Destroy(empanadaCruda); // Destruye la empanada cruda
        empanadaCocinada = Instantiate(empanadaCocinadaPrefab, hornoPosition.position, Quaternion.identity);
        empanadaCocinada.transform.SetParent(hornoPosition);
        empanadaCocinada.transform.localPosition = Vector3.zero;

        cooking = false;
        empanadaListo = true;

        cookTimeText.text = "Empanada lista"; // Cambiar el texto cuando está lista
    }

    private void GiveCookedEmpanada()
    {
        itemHandler.EmpanadasInstance = empanadaCocinada; // Asignar la empanada cocinada al jugador
        empanadaCocinada.transform.SetParent(itemHandler.ItemPosition);
        empanadaCocinada.transform.localPosition = Vector3.zero;

        empanadaCocinada = null;
        empanadaListo = false;
        itemHandler.hasEmpanadas = true;

        cookTimeText.gameObject.SetActive(false); // Ocultar el texto cuando la empanada es recogida

        itemHandler.ExternalMessage("Tienes empanadas", 2f);
    }
}
