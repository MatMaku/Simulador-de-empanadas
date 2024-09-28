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
    public GameObject empanadasCrudasPrefab; // Prefab para instanciar empanadas crudas
    public GameObject empanadasPrefab; // Prefab para instanciar empanadas cocidas

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
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.4f;

            Destroy(itemHandler.CarneInstance);
            itemOnTable = Instantiate(carnePrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.CarneInstance = null;
            itemHandler.hasCarne = false;
        }
        else if (itemHandler.hasMasa)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.4f;

            Destroy(itemHandler.MasaInstance);
            itemOnTable = Instantiate(masaPrefab, posicionSobreMesa, Quaternion.identity);
            itemHandler.MasaInstance = null;
            itemHandler.hasMasa = false;
        }
        else if (itemHandler.hasCarnePicada)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.35f;

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
        else if (itemHandler.hasEmpanadasCrudas)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.4f;

            int Valor = itemHandler.EmpanadasCrudasInstance.GetComponent<ValorEmpanadas>().Valor;

            Destroy(itemHandler.EmpanadasCrudasInstance);
            itemOnTable = Instantiate(empanadasCrudasPrefab, posicionSobreMesa, Quaternion.identity);
            itemOnTable.GetComponent<ValorEmpanadas>().Valor = Valor;

            itemHandler.EmpanadasCrudasInstance = null;
            itemHandler.hasEmpanadasCrudas = false;
        }
        else if (itemHandler.hasEmpanadas)
        {
            Vector3 posicionSobreMesa = transform.position + Vector3.up * 0.4f;

            int Valor = itemHandler.EmpanadasCrudasInstance.GetComponent<ValorEmpanadas>().Valor;

            Destroy(itemHandler.EmpanadasInstance);
            itemOnTable = Instantiate(empanadasPrefab, posicionSobreMesa, Quaternion.identity);
            itemOnTable.GetComponent<ValorEmpanadas>().Valor = Valor;

            itemHandler.EmpanadasInstance = null;
            itemHandler.hasEmpanadas = false;
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
            else if (itemName == "Tapas(Clone)")
            {
                itemHandler.TapasInstance = Instantiate(tapasPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.TapasInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasTapas = true;
            }
            else if (itemName == "Empanadas crudas(Clone)")
            {
                int Valor = itemOnTable.GetComponent<ValorEmpanadas>().Valor;

                itemHandler.EmpanadasCrudasInstance = Instantiate(empanadasCrudasPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.EmpanadasCrudasInstance.GetComponent<ValorEmpanadas>().Valor = Valor;
                itemHandler.EmpanadasCrudasInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasEmpanadasCrudas = true;
            }
            else if (itemName == "Empanadas(Clone)")
            {
                int Valor = itemOnTable.GetComponent<ValorEmpanadas>().Valor;

                itemHandler.EmpanadasInstance = Instantiate(empanadasPrefab, itemHandler.ItemPosition.position, Quaternion.identity);
                itemHandler.EmpanadasInstance.GetComponent<ValorEmpanadas>().Valor = Valor;
                itemHandler.EmpanadasInstance.transform.SetParent(itemHandler.ItemPosition);
                itemHandler.hasEmpanadas = true;
            }

            Destroy(itemOnTable);
            itemOnTable = null;
        }
    }
}
