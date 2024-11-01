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
    private DatosJuego datosJuego;

    void Start()
    {
        datosJuego = SistemaGuardado.CargarDatos();

        itemHandler = FindObjectOfType<ItemHandler>(); 
        cookTimeText.gameObject.SetActive(false);

        if (datosJuego.MejoraCocina)
        {
            cookTime = 5f;
        }
        else
        {
            cookTime = 10f;
        }
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
        if (!empanadaListo && !cooking && itemHandler.hasEmpanadasCrudas) // Verifica si el jugador tiene empanada cruda
        {
            StartCooking();
        }
        else if (empanadaListo && itemHandler.HasEspacio()) // Si la empanada est� lista y el jugador tiene espacio
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

        cookTimeText.gameObject.SetActive(true); // Mostrar el texto de cocci�n
    }

    private void FinishCooking()
    {
        int Valor = empanadaCruda.GetComponent<ValorEmpanadas>().Valor;

        Destroy(empanadaCruda);
        empanadaCocinada = Instantiate(empanadaCocinadaPrefab, hornoPosition.position, Quaternion.identity);
        empanadaCocinada.GetComponent<ValorEmpanadas>().Valor = Valor;
        empanadaCocinada.transform.SetParent(hornoPosition);
        empanadaCocinada.transform.localPosition = Vector3.zero;

        cooking = false;
        empanadaListo = true;

        cookTimeText.text = "Empanada lista"; // Cambiar el texto cuando est� lista
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
