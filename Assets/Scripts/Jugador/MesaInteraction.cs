using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaInteraction : MonoBehaviour
{
    public GameObject carnePrefab; // Prefab para instanciar carne
    public GameObject masaPrefab; // Prefab para instanciar masa
    public GameObject carnePicadaPrefab; // Prefab para instanciar carne picada
    public GameObject planchaMasaPrefab; // Prefab para instanciar plancha de masa
    public GameObject tapasPrefab; // Prefab para instanciar tapas
    public GameObject empanadasCarneCrudasPrefab;
    public GameObject empanadasCarnePrefab;
    public GameObject empanadasJyQCrudasPrefab;
    public GameObject empanadasJyQPrefab;
    public GameObject jamonPrefab;
    public GameObject quesoPrefab;
    public GameObject jyqPrefab;
    public GameObject PizzaCrudaPrefab;
    public GameObject PizzaPrefab;

    private GameObject itemOnTable; // Almacena el item en la mesa
    private ItemHandler itemHandler; // Referencia al manejador de items

    void Start()
    {
        itemHandler = FindObjectOfType<ItemHandler>(); // Encuentra el script ItemHandler
    }

    public void Interact()
    {
        // Si hay un objeto en la mesa y el jugador tiene espacio, lo recoge
        if (itemOnTable != null && itemHandler.HasEspacio())
        {
            PickUpItem();
        }
        // Si no hay un objeto en la mesa y el jugador tiene un ítem, lo deja
        else if (itemOnTable == null && !itemHandler.HasEspacio())
        {
            PlaceItemOnTable();
        }
    }

    private void PlaceItemOnTable()
    {
        if (itemHandler.hasCarne)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.CarneInstance);
            itemOnTable = Instantiate(carnePrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.CarneInstance = null;
            itemHandler.hasCarne = false;
        }
        else if (itemHandler.hasMasa)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.MasaInstance);
            itemOnTable = Instantiate(masaPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.MasaInstance = null;
            itemHandler.hasMasa = false;
        }
        else if (itemHandler.hasCarnePicada)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.CarnePicadaInstance);
            itemOnTable = Instantiate(carnePicadaPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.CarnePicadaInstance = null;
            itemHandler.hasCarnePicada = false;
        }
        else if (itemHandler.hasPlanchaMasa)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.PlanchaMasaInstance);
            itemOnTable = Instantiate(planchaMasaPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.PlanchaMasaInstance = null;
            itemHandler.hasPlanchaMasa = false;
        }
        else if (itemHandler.hasTapas)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.TapasInstance);
            itemOnTable = Instantiate(tapasPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.TapasInstance = null;
            itemHandler.hasTapas = false;
        }
        else if (itemHandler.hasEmpanadasCarneCrudas)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            int Valor = itemHandler.EmpanadasCarneCrudasInstance.GetComponent<ValorEmpanadas>().Valor;

            Destroy(itemHandler.EmpanadasCarneCrudasInstance);
            itemOnTable = Instantiate(empanadasCarneCrudasPrefab, posicionSobreMesa, Quaternion.identity);
            itemOnTable.GetComponent<ValorEmpanadas>().Valor = Valor;

            itemHandler.EmpanadasCarneCrudasInstance = null;
            itemHandler.hasEmpanadasCarneCrudas = false;
        }
        else if (itemHandler.hasEmpanadasCarne)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            int Valor = itemHandler.EmpanadasCarneInstance.GetComponent<ValorEmpanadas>().Valor;

            Destroy(itemHandler.EmpanadasCarneInstance);
            itemOnTable = Instantiate(empanadasCarnePrefab, posicionSobreMesa, Quaternion.identity);
            itemOnTable.GetComponent<ValorEmpanadas>().Valor = Valor;

            itemHandler.EmpanadasCarneInstance = null;
            itemHandler.hasEmpanadasCarne = false;
        }
        else if (itemHandler.hasEmpanadasJyQCrudas)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            int Valor = itemHandler.EmpanadasJyQCrudasInstance.GetComponent<ValorEmpanadas>().Valor;

            Destroy(itemHandler.EmpanadasJyQCrudasInstance);
            itemOnTable = Instantiate(empanadasJyQCrudasPrefab, posicionSobreMesa, Quaternion.identity);
            itemOnTable.GetComponent<ValorEmpanadas>().Valor = Valor;

            itemHandler.EmpanadasJyQCrudasInstance = null;
            itemHandler.hasEmpanadasJyQCrudas = false;
        }
        else if (itemHandler.hasEmpanadasJyQ)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            int Valor = itemHandler.EmpanadasJyQInstance.GetComponent<ValorEmpanadas>().Valor;

            Destroy(itemHandler.EmpanadasJyQInstance);
            itemOnTable = Instantiate(empanadasJyQPrefab, posicionSobreMesa, Quaternion.identity);
            itemOnTable.GetComponent<ValorEmpanadas>().Valor = Valor;

            itemHandler.EmpanadasJyQInstance = null;
            itemHandler.hasEmpanadasJyQ = false;
        }
        else if (itemHandler.hasJamon)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.JamonInstance);
            itemOnTable = Instantiate(jamonPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.JamonInstance = null;
            itemHandler.hasJamon = false;
        }
        else if (itemHandler.hasQueso)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.QuesoInstance);
            itemOnTable = Instantiate(quesoPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.QuesoInstance = null;
            itemHandler.hasQueso = false;
        }
        else if (itemHandler.hasJyQ)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.JyQInstance);
            itemOnTable = Instantiate(jyqPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.JyQInstance = null;
            itemHandler.hasJyQ = false;
        }
        else if (itemHandler.hasPizzaCruda)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.PizzaCrudaInstance);
            itemOnTable = Instantiate(PizzaCrudaPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.PizzaCrudaInstance = null;
            itemHandler.hasPizzaCruda = false;
        }
        else if (itemHandler.hasPizza)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.3f;

            Destroy(itemHandler.PizzaInstance);
            itemOnTable = Instantiate(PizzaPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.PizzaInstance = null;
            itemHandler.hasPizza = false;
        }

        itemOnTable.transform.SetParent(transform);
    }

    private void PickUpItem()
    {
        if (itemOnTable != null)
        {
            string itemName = itemOnTable.name; 

            if (itemName == "Carne(Clone)")
            {
                itemHandler.CarneInstance = Instantiate(carnePrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.CarneInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasCarne = true;
            }
            else if (itemName == "Masa(Clone)")
            {
                itemHandler.MasaInstance = Instantiate(masaPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.MasaInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasMasa = true;
            }
            else if (itemName == "Carne picada(Clone)")
            {
                itemHandler.CarnePicadaInstance = Instantiate(carnePicadaPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.CarnePicadaInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasCarnePicada = true;
            }
            else if (itemName == "Plancha de masa(Clone)")
            {
                itemHandler.PlanchaMasaInstance = Instantiate(planchaMasaPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.PlanchaMasaInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasPlanchaMasa = true;
            }
            else if (itemName == "Tapas de empanada(Clone)")
            {
                itemHandler.TapasInstance = Instantiate(tapasPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.TapasInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasTapas = true;
            }
            else if (itemName == "Empanadas carne crudas(Clone)")
            {
                int Valor = itemOnTable.GetComponent<ValorEmpanadas>().Valor;

                itemHandler.EmpanadasCarneCrudasInstance = Instantiate(empanadasCarneCrudasPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.EmpanadasCarneCrudasInstance.GetComponent<ValorEmpanadas>().Valor = Valor;
                itemHandler.EmpanadasCarneCrudasInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasEmpanadasCarneCrudas = true;
            }
            else if (itemName == "Empanadas carne(Clone)")
            {
                int Valor = itemOnTable.GetComponent<ValorEmpanadas>().Valor;

                itemHandler.EmpanadasCarneInstance = Instantiate(empanadasCarnePrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.EmpanadasCarneInstance.GetComponent<ValorEmpanadas>().Valor = Valor;
                itemHandler.EmpanadasCarneInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasEmpanadasCarne = true;
            }
            else if (itemName == "Empanadas JyQ crudas(Clone)")
            {
                int Valor = itemOnTable.GetComponent<ValorEmpanadas>().Valor;

                itemHandler.EmpanadasJyQCrudasInstance = Instantiate(empanadasJyQCrudasPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.EmpanadasJyQCrudasInstance.GetComponent<ValorEmpanadas>().Valor = Valor;
                itemHandler.EmpanadasJyQCrudasInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasEmpanadasJyQCrudas = true;
            }
            else if (itemName == "Empanadas JyQ(Clone)")
            {
                int Valor = itemOnTable.GetComponent<ValorEmpanadas>().Valor;

                itemHandler.EmpanadasJyQInstance = Instantiate(empanadasJyQPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.EmpanadasJyQInstance.GetComponent<ValorEmpanadas>().Valor = Valor;
                itemHandler.EmpanadasJyQInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasEmpanadasJyQ = true;
            }
            else if (itemName == "Jamon(Clone)")
            {
                itemHandler.JamonInstance = Instantiate(jamonPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.JamonInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasJamon = true;
            }
            else if (itemName == "Queso(Clone)")
            {
                itemHandler.QuesoInstance = Instantiate(quesoPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.QuesoInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasQueso = true;
            }
            else if (itemName == "JyQ(Clone)")
            {
                itemHandler.JyQInstance = Instantiate(jyqPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.JyQInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasJyQ = true;
            }
            else if (itemName == "Pizza cruda(Clone)")
            {
                itemHandler.PizzaCrudaInstance = Instantiate(PizzaCrudaPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.PizzaCrudaInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasPizzaCruda = true;
            }
            else if (itemName == "Pizza(Clone)")
            {
                itemHandler.PizzaInstance = Instantiate(PizzaPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.PizzaInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasPizza = true;
            }

            Destroy(itemOnTable);
            itemOnTable = null;
        }
    }
}
