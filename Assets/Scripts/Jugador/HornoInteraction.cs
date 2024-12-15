using System.Collections;
using TMPro;
using UnityEngine;

public class HornoInteraction : MonoBehaviour
{
    public Transform hornoPosition;
    public GameObject empanadaCarneCocinadaPrefab;
    public GameObject empanadaJyQCocinadaPrefab;
    public GameObject PizzaCocinadaPrefab;
    public TextMeshPro cookTimeText; // El texto sobre el horno
    private GameObject empanadaCarneCruda;
    private GameObject empanadaCarneCocinada;
    private GameObject empanadaJyQCruda;
    private GameObject empanadaJyQCocinada;
    private GameObject PizzaCruda;
    private GameObject PizzaCocinada;
    private bool cookingCarne = false;
    private bool cookingJyQ = false;
    private bool cookingPizza = false;
    private bool empanadaCarneLista = false;
    private bool empanadaJyQLista = false;
    private bool PizzaLista = false;
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
        if (cookingCarne)
        {
            remainingTime -= Time.deltaTime;
            cookTimeText.text = "Cocinando: " + Mathf.Ceil(remainingTime).ToString() + "s";

            if (remainingTime <= 0f)
            {
                FinishCookingCarne();
            }
        }

        if (cookingJyQ)
        {
            remainingTime -= Time.deltaTime;
            cookTimeText.text = "Cocinando: " + Mathf.Ceil(remainingTime).ToString() + "s";

            if (remainingTime <= 0f)
            {
                FinishCookingJyQ();
            }
        }

        if (cookingPizza)
        {
            remainingTime -= Time.deltaTime;
            cookTimeText.text = "Cocinando: " + Mathf.Ceil(remainingTime).ToString() + "s";

            if (remainingTime <= 0f)
            {
                FinishCookingPizza();
            }
        }
    }

    public void Interact()
    {
        if (!empanadaCarneLista && !empanadaJyQLista && !PizzaLista && !cookingCarne && !cookingJyQ && !cookingPizza && itemHandler.hasEmpanadasCarneCrudas)
        {
            StartCookingCarne();
        }
        else if (empanadaCarneLista && itemHandler.HasEspacio())
        {
            GiveEmpanadaCarne();
        }
        else if (!empanadaCarneLista && !empanadaJyQLista && !PizzaLista && !cookingCarne && !cookingJyQ && !cookingPizza && itemHandler.hasEmpanadasJyQCrudas)
        {
            StartCookingJyQ();
        }
        else if (empanadaJyQLista && itemHandler.HasEspacio())
        {
            GiveEmpanadaJyQ();
        }
        else if (!empanadaCarneLista && !empanadaJyQLista && !PizzaLista && !cookingCarne && !cookingJyQ && !cookingPizza && itemHandler.hasPizzaCruda)
        {
            StartCookingPizza();
        }
        else if (PizzaLista && itemHandler.HasEspacio())
        {
            GivePizza();
        }
    }

    private void StartCookingCarne()
    {
        cookingCarne = true;
        remainingTime = cookTime;

        empanadaCarneCruda = itemHandler.EmpanadasCarneCrudasInstance; // Obtener la empanada cruda
        empanadaCarneCruda.transform.SetParent(hornoPosition);
        empanadaCarneCruda.transform.localPosition = Vector3.zero;

        itemHandler.EmpanadasCarneCrudasInstance = null;
        itemHandler.hasEmpanadasCarneCrudas = false;

        cookTimeText.gameObject.SetActive(true); // Mostrar el texto de cocción
    }

    private void FinishCookingCarne()
    {
        int Valor = empanadaCarneCruda.GetComponent<ValorEmpanadas>().Valor;

        Destroy(empanadaCarneCruda);
        empanadaCarneCocinada = Instantiate(empanadaCarneCocinadaPrefab, hornoPosition.position, Quaternion.identity);
        empanadaCarneCocinada.GetComponent<ValorEmpanadas>().Valor = Valor;
        empanadaCarneCocinada.transform.SetParent(hornoPosition);
        empanadaCarneCocinada.transform.localPosition = Vector3.zero;

        cookingCarne = false;
        empanadaCarneLista = true;

        cookTimeText.text = "Empanada lista"; // Cambiar el texto cuando está lista
    }

    private void GiveEmpanadaCarne()
    {
        itemHandler.EmpanadasCarneInstance = empanadaCarneCocinada; // Asignar la empanada cocinada al jugador
        empanadaCarneCocinada.transform.SetParent(itemHandler.ItemPosition);
        empanadaCarneCocinada.transform.localPosition = Vector3.zero;

        empanadaCarneCocinada = null;
        empanadaCarneLista = false;
        itemHandler.hasEmpanadasCarne = true;

        cookTimeText.gameObject.SetActive(false); // Ocultar el texto cuando la empanada es recogida

        itemHandler.ExternalMessage("Tienes empanadas de carne", 2f);
    }

    private void StartCookingJyQ()
    {
        cookingJyQ = true;
        remainingTime = cookTime;

        empanadaJyQCruda = itemHandler.EmpanadasJyQCrudasInstance; // Obtener la empanada cruda
        empanadaJyQCruda.transform.SetParent(hornoPosition);
        empanadaJyQCruda.transform.localPosition = Vector3.zero;

        itemHandler.EmpanadasJyQCrudasInstance = null;
        itemHandler.hasEmpanadasJyQCrudas = false;

        cookTimeText.gameObject.SetActive(true); // Mostrar el texto de cocción
    }

    private void FinishCookingJyQ()
    {
        int Valor = empanadaJyQCruda.GetComponent<ValorEmpanadas>().Valor;

        Destroy(empanadaJyQCruda);
        empanadaJyQCocinada = Instantiate(empanadaJyQCocinadaPrefab, hornoPosition.position, Quaternion.identity);
        empanadaJyQCocinada.GetComponent<ValorEmpanadas>().Valor = Valor;
        empanadaJyQCocinada.transform.SetParent(hornoPosition);
        empanadaJyQCocinada.transform.localPosition = Vector3.zero;

        cookingJyQ = false;
        empanadaJyQLista = true;

        cookTimeText.text = "Empanada lista"; // Cambiar el texto cuando está lista
    }

    private void GiveEmpanadaJyQ()
    {
        itemHandler.EmpanadasJyQInstance = empanadaJyQCocinada; // Asignar la empanada cocinada al jugador
        empanadaJyQCocinada.transform.SetParent(itemHandler.ItemPosition);
        empanadaJyQCocinada.transform.localPosition = Vector3.zero;

        empanadaJyQCocinada = null;
        empanadaJyQLista = false;
        itemHandler.hasEmpanadasJyQ = true;

        cookTimeText.gameObject.SetActive(false); // Ocultar el texto cuando la empanada es recogida

        itemHandler.ExternalMessage("Tienes empanadas de JyQ", 2f);
    }

    private void StartCookingPizza()
    {
        cookingPizza = true;
        remainingTime = cookTime;

        PizzaCruda = itemHandler.PizzaCrudaInstance;
        PizzaCruda.transform.SetParent(hornoPosition);
        PizzaCruda.transform.localPosition = Vector3.zero;

        itemHandler.PizzaCrudaInstance = null;
        itemHandler.hasPizzaCruda = false;

        cookTimeText.gameObject.SetActive(true); // Mostrar el texto de cocción
    }

    private void FinishCookingPizza()
    {
        int Valor = PizzaCruda.GetComponent<ValorEmpanadas>().Valor;

        Destroy(PizzaCruda);
        PizzaCocinada = Instantiate(PizzaCocinadaPrefab, hornoPosition.position, Quaternion.identity);
        PizzaCocinada.GetComponent<ValorEmpanadas>().Valor = Valor;
        PizzaCocinada.transform.SetParent(hornoPosition);
        PizzaCocinada.transform.localPosition = Vector3.zero;

        cookingPizza = false;
        PizzaLista = true;

        cookTimeText.text = "Pizza lista"; // Cambiar el texto cuando está lista
    }

    private void GivePizza()
    {
        itemHandler.PizzaInstance = PizzaCocinada;
        PizzaCocinada.transform.SetParent(itemHandler.ItemPosition);
        PizzaCocinada.transform.localPosition = Vector3.zero;

        PizzaCocinada = null;
        PizzaLista = false;
        itemHandler.hasPizza = true;

        cookTimeText.gameObject.SetActive(false); // Ocultar el texto cuando la empanada es recogida

        itemHandler.ExternalMessage("Tienes pizza", 2f);
    }
}
