using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemHandler : MonoBehaviour
{
    public GameObject CarnePrefab;
    public GameObject MasaPrefab;
    public GameObject CarnePicadaPrefab;
    public GameObject PlanchaMasaPrefab;
    public GameObject TapasPrefab;
    public GameObject EmpanadasCarneCrudasPrefab;
    public GameObject EmpanadasCarnePrefab;
    public GameObject EmpanadasJyQCrudasPrefab;
    public GameObject EmpanadasJyQPrefab;
    public GameObject BebidaPrefab;
    public GameObject JamonPrefab;
    public GameObject QuesoPrefab;
    public GameObject JyQPrefab;
    public GameObject PizzaCrudaPrefab;
    public GameObject PizzaPrefab;
    public Transform ItemPosition;
    public TextMeshProUGUI messageText;

    [HideInInspector] public GameObject CarneInstance;
    [HideInInspector] public GameObject MasaInstance;
    [HideInInspector] public GameObject CarnePicadaInstance;
    [HideInInspector] public GameObject PlanchaMasaInstance;
    [HideInInspector] public GameObject TapasInstance;
    [HideInInspector] public GameObject EmpanadasCarneCrudasInstance;
    [HideInInspector] public GameObject EmpanadasCarneInstance;
    [HideInInspector] public GameObject EmpanadasJyQCrudasInstance;
    [HideInInspector] public GameObject EmpanadasJyQInstance;
    [HideInInspector] public GameObject BebidaInstance;
    [HideInInspector] public GameObject JamonInstance;
    [HideInInspector] public GameObject QuesoInstance;
    [HideInInspector] public GameObject PizzaCrudaInstance;
    [HideInInspector] public GameObject PizzaInstance;
    [HideInInspector] public GameObject JyQInstance;

    [HideInInspector] public bool hasCarne = false;
    [HideInInspector] public bool hasMasa = false;
    [HideInInspector] public bool hasCarnePicada = false;
    [HideInInspector] public bool hasPlanchaMasa = false;
    [HideInInspector] public bool hasTapas = false;
    [HideInInspector] public bool hasEmpanadasCarneCrudas = false;
    [HideInInspector] public bool hasEmpanadasCarne = false;
    [HideInInspector] public bool hasEmpanadasJyQCrudas = false;
    [HideInInspector] public bool hasEmpanadasJyQ = false;
    [HideInInspector] public bool hasBebida = false;
    [HideInInspector] public bool hasJamon = false;
    [HideInInspector] public bool hasQueso = false;
    [HideInInspector] public bool hasJyQ = false;
    [HideInInspector] public bool hasPizzaCruda = false;
    [HideInInspector] public bool hasPizza = false;
    [HideInInspector] public bool PrimerClienteAtendido = false;

    void Start()
    {
        messageText.gameObject.SetActive(false);
    }

    public void PickUpJamon()
    {
        if (HasEspacio())
        {

            JamonInstance = Instantiate(JamonPrefab, ItemPosition.position, Quaternion.identity);
            JamonInstance.transform.SetParent(ItemPosition);
            JamonInstance.transform.localPosition = Vector3.zero;
            hasJamon = true;

            StartCoroutine(ShowMessage("Recogiste jamon", 2f));
        }
    }

    public void PickUpQueso()
    {
        if (HasEspacio())
        {

            QuesoInstance = Instantiate(QuesoPrefab, ItemPosition.position, Quaternion.identity);
            QuesoInstance.transform.SetParent(ItemPosition);
            QuesoInstance.transform.localPosition = Vector3.zero;
            hasQueso = true;

            StartCoroutine(ShowMessage("Recogiste queso", 2f));
        }
    }

    public void PickUpJyQ()
    {
        if (HasEspacio())
        {

            JyQInstance = Instantiate(JyQPrefab, ItemPosition.position, Quaternion.identity);
            JyQInstance.transform.SetParent(ItemPosition);
            JyQInstance.transform.localPosition = Vector3.zero;
            hasJyQ = true;

            StartCoroutine(ShowMessage("Tienes jamon y queso", 2f));
        }
    }

    public void PickUpPizza(int Valor)
    {
        if (HasEspacio())
        {

            PizzaCrudaInstance = Instantiate(PizzaCrudaPrefab, ItemPosition.position, Quaternion.identity);
            PizzaCrudaInstance.transform.SetParent(ItemPosition);
            PizzaCrudaInstance.transform.localPosition = Vector3.zero;
            hasPizzaCruda = true;

            PizzaCrudaInstance.GetComponent<ValorEmpanadas>().Valor = Valor;

            StartCoroutine(ShowMessage("Tienes pizza", 2f));
        }
    }

    public void PickUpCarne()
    {
        if (HasEspacio())
        {
            
            CarneInstance = Instantiate(CarnePrefab, ItemPosition.position, Quaternion.identity);
            CarneInstance.transform.SetParent(ItemPosition);
            CarneInstance.transform.localPosition = Vector3.zero;
            hasCarne = true;

            StartCoroutine(ShowMessage("Recogiste carne", 2f));
        }
    }

    public void PickUpMasa()
    {
        if (HasEspacio())
        {

            MasaInstance = Instantiate(MasaPrefab, ItemPosition.position, Quaternion.identity);
            MasaInstance.transform.SetParent(ItemPosition);
            MasaInstance.transform.localPosition = Vector3.zero;
            hasMasa = true;

            StartCoroutine(ShowMessage("Recogiste masa", 2f));
        }
    }

    public void PickUpCarnePicada()
    {
        if (HasEspacio())
        {

            CarnePicadaInstance = Instantiate(CarnePicadaPrefab, ItemPosition.position, Quaternion.identity);
            CarnePicadaInstance.transform.SetParent(ItemPosition);
            CarnePicadaInstance.transform.localPosition = Vector3.zero;
            hasCarnePicada = true;

            StartCoroutine(ShowMessage("Tienes carne picada", 2f));
        }
    }

    public void PickPlanchaMasa()
    {
        if (HasEspacio())
        {

            PlanchaMasaInstance = Instantiate(PlanchaMasaPrefab, ItemPosition.position, Quaternion.identity);
            PlanchaMasaInstance.transform.SetParent(ItemPosition);
            PlanchaMasaInstance.transform.localPosition = Vector3.zero;
            hasPlanchaMasa = true;

            StartCoroutine(ShowMessage("Tienes plancha de masa", 2f));
        }
    }

    public void PickUpTapas()
    {
        if (HasEspacio())
        {

            TapasInstance = Instantiate(TapasPrefab, ItemPosition.position, Quaternion.identity);
            TapasInstance.transform.SetParent(ItemPosition);
            TapasInstance.transform.localPosition = Vector3.zero;
            hasTapas = true;

            StartCoroutine(ShowMessage("Tienes tapas de empanada", 2f));
        }
    }

    public void PickUpEmpanadasCarneCrudas(int Valor)
    {
        if (HasEspacio())
        {
            EmpanadasCarneCrudasInstance = Instantiate(EmpanadasCarneCrudasPrefab, ItemPosition.position, Quaternion.identity);
            EmpanadasCarneCrudasInstance.transform.SetParent(ItemPosition);
            EmpanadasCarneCrudasInstance.transform.localPosition = Vector3.zero;
            hasEmpanadasCarneCrudas = true;

            EmpanadasCarneCrudasInstance.GetComponent<ValorEmpanadas>().Valor = Valor;

            StartCoroutine(ShowMessage("Tienes empanadas crudas", 2f));
        }
    }

    public void PickUpEmpanadasJyQCrudas(int Valor)
    {
        if (HasEspacio())
        {
            EmpanadasJyQCrudasInstance = Instantiate(EmpanadasJyQCrudasPrefab, ItemPosition.position, Quaternion.identity);
            EmpanadasJyQCrudasInstance.transform.SetParent(ItemPosition);
            EmpanadasJyQCrudasInstance.transform.localPosition = Vector3.zero;
            hasEmpanadasJyQCrudas = true;

            EmpanadasJyQCrudasInstance.GetComponent<ValorEmpanadas>().Valor = Valor;

            StartCoroutine(ShowMessage("Tienes empanadas de JyQ crudas", 2f));
        }
    }

    public void PickUpBebida()
    {
        if (HasEspacio())
        {
            BebidaInstance = Instantiate(BebidaPrefab, ItemPosition.position, Quaternion.identity);
            BebidaInstance.transform.SetParent(ItemPosition);
            BebidaInstance.transform.localPosition = Vector3.zero;
            hasBebida = true;

            StartCoroutine(ShowMessage("Tienes bebida", 2f));
        }
    }

    public void PlaceCarnePicadaOnTable(Transform tablePosition)
    {
        if (hasCarnePicada)
        {
            Destroy(CarnePicadaInstance);

            GameObject CarneEnMesa = Instantiate(CarnePicadaPrefab, new Vector3(0,0,0), Quaternion.identity);
            CarneEnMesa.transform.SetParent(tablePosition);

            CarneEnMesa.transform.localPosition = new Vector3(.3f, .5f, 0f);
            CarneEnMesa.transform.localRotation = Quaternion.identity;

            
            hasCarnePicada = false;
            StartCoroutine(ShowMessage("Carne picada colocada en la mesa", 2f));
        }
    }

    public void PlaceTapasOnTable(Transform tablePosition)
    {
        if (hasTapas)
        {
            Destroy(TapasInstance);

            GameObject TapasEnMesa = Instantiate(TapasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            TapasEnMesa.transform.SetParent(tablePosition);

            TapasEnMesa.transform.localPosition = new Vector3(-.3f, .5f, 0f);
            TapasEnMesa.transform.localRotation = Quaternion.identity;


            hasTapas = false;
            StartCoroutine(ShowMessage("Tapas colocadas en la mesa", 2f));
        }
    }

    public void PlaceJamonOnTable(Transform tablePosition)
    {
        if (hasJamon)
        {
            Destroy(JamonInstance);

            GameObject JamonEnMesa = Instantiate(JamonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            JamonEnMesa.transform.SetParent(tablePosition);

            JamonEnMesa.transform.localPosition = new Vector3(-.3f, .5f, 0f);
            JamonEnMesa.transform.localRotation = Quaternion.identity;


            hasJamon = false;
            StartCoroutine(ShowMessage("Jamon colocado en la mesa", 2f));
        }
    }

    public void PlaceQuesoOnTable(Transform tablePosition)
    {
        if (hasQueso)
        {
            Destroy(QuesoInstance);

            GameObject QuesoEnMesa = Instantiate(QuesoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            QuesoEnMesa.transform.SetParent(tablePosition);

            QuesoEnMesa.transform.localPosition = new Vector3(.3f, .5f, 0f);
            QuesoEnMesa.transform.localRotation = Quaternion.identity;


            hasQueso = false;
            StartCoroutine(ShowMessage("Queso colocado en la mesa", 2f));
        }
    }

    public void PlaceJyQOnTable(Transform tablePosition)
    {
        if (hasJyQ)
        {
            Destroy(JyQInstance);

            GameObject JyQEnMesa = Instantiate(JyQPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            JyQEnMesa.transform.SetParent(tablePosition);

            JyQEnMesa.transform.localPosition = new Vector3(.3f, .5f, 0f);
            JyQEnMesa.transform.localRotation = Quaternion.identity;


            hasJyQ = false;
            StartCoroutine(ShowMessage("Jamon y queso colocado en la mesa", 2f));
        }
    }

    public void PlaceMasaOnTable(Transform tablePosition)
    {
        if (hasPlanchaMasa)
        {
            Destroy(PlanchaMasaInstance);

            GameObject MasaEnMesa = Instantiate(PlanchaMasaPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            MasaEnMesa.transform.SetParent(tablePosition);

            MasaEnMesa.transform.localPosition = new Vector3(-.3f, .5f, 0f);
            MasaEnMesa.transform.localRotation = Quaternion.identity;


            hasPlanchaMasa = false;
            StartCoroutine(ShowMessage("Masa colocado en la mesa", 2f));
        }
    }

    public void GiveEmpanadasCarne()
    {
        if (hasEmpanadasCarne)
        {
            Destroy(EmpanadasCarneInstance);
            hasEmpanadasCarne = false;
            PrimerClienteAtendido = true;

            StartCoroutine(ShowMessage("Empanadas de carne entregadas", 2f));
        }
    }

    public void GiveEmpanadasJyQ()
    {
        if (hasEmpanadasJyQ)
        {
            Destroy(EmpanadasJyQInstance);
            hasEmpanadasJyQ = false;

            StartCoroutine(ShowMessage("Empanadas de JyQ entregada", 2f));
        }
    }

    public void GivePizza()
    {
        if (hasPizza)
        {
            Destroy(PizzaInstance);
            hasPizza = false;

            StartCoroutine(ShowMessage("Pizza entregada", 2f));
        }
    }

    public void GiveBebidas()
    {
        if (hasBebida)
        {
            Destroy(BebidaInstance);
            hasBebida = false;

            StartCoroutine(ShowMessage("Bebida entregada", 2f));
        }
    }

    public void DiscardItem()
    {
        if (hasCarne || hasMasa || hasCarnePicada || hasPlanchaMasa || hasTapas || hasEmpanadasCarne || hasEmpanadasCarneCrudas || hasBebida || hasJamon || hasQueso || hasJyQ || hasPizzaCruda || hasPizza || hasEmpanadasJyQ || hasEmpanadasJyQCrudas)
        {
            Destroy(CarneInstance);
            Destroy(MasaInstance);
            Destroy(CarnePicadaInstance);
            Destroy(PlanchaMasaInstance);
            Destroy(TapasInstance);
            Destroy(EmpanadasCarneInstance);
            Destroy(EmpanadasCarneCrudasInstance);
            Destroy(EmpanadasJyQInstance);
            Destroy(EmpanadasJyQCrudasInstance);
            Destroy(BebidaInstance);
            Destroy(JamonInstance);
            Destroy(QuesoInstance);
            Destroy(JyQInstance);
            Destroy(PizzaCrudaInstance);
            Destroy(PizzaInstance);
            hasCarne = false;
            hasMasa = false;
            hasCarnePicada = false;
            hasPlanchaMasa = false;
            hasTapas = false;
            hasEmpanadasCarne = false;
            hasEmpanadasCarneCrudas = false;
            hasEmpanadasJyQ = false;
            hasEmpanadasJyQCrudas = false;
            hasBebida = false;
            hasJamon = false;
            hasQueso = false;
            hasJyQ = false;
            hasPizzaCruda = false;
            hasPizza = false;
        }
        else
        {
            StartCoroutine(ShowMessage("No tienes nada que descartar", 2f));
        }
    }

    public bool HasEspacio()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadasCarne && !hasEmpanadasCarneCrudas && !hasBebida && !hasJamon && !hasQueso && !hasJyQ && !hasPizzaCruda && !hasPizza && !hasEmpanadasJyQ && !hasEmpanadasJyQCrudas)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ExternalMessage(string message, float delay)
    {
        StartCoroutine(ShowMessage(message, delay));
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false);
    }
}
