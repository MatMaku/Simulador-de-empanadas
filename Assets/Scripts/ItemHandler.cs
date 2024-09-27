using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemHandler : MonoBehaviour
{
    public GameObject CarnePrefab;
    public GameObject MasaPrefab;
    public GameObject CarnePicadaPrefab;
    public GameObject PlanchaMasaPrefab;
    public GameObject TapasPrefab;
    public GameObject EmpanadasCrudasPrefab;
    public GameObject EmpanadasPrefab;
    public Transform ItemPosition;
    public TextMeshProUGUI messageText;

    private GameObject CarneInstance;
    private GameObject MasaInstance;
    private GameObject CarnePicadaInstance;
    private GameObject PlanchaMasaInstance;
    private GameObject TapasInstance;
    private GameObject EmpanadasCrudasInstance;
    private GameObject EmpanadasInstance;

    private bool hasCarne = false;
    private bool hasMasa = false;
    private bool hasCarnePicada = false;
    private bool hasPlanchaMasa = false;
    private bool hasTapas = false;
    private bool hasEmpanadasCrudas = false;
    private bool hasEmpanadas = false;

    void Start()
    {
        messageText.gameObject.SetActive(false);
    }

    public void PickUpCarne()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {
            
            CarneInstance = Instantiate(CarnePrefab, ItemPosition.position, Quaternion.identity);
            CarneInstance.transform.SetParent(ItemPosition);
            CarneInstance.transform.localPosition = Vector3.zero;
            hasCarne = true;

            StartCoroutine(ShowMessage("Recogiste carne", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PickUpMasa()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {

            MasaInstance = Instantiate(MasaPrefab, ItemPosition.position, Quaternion.identity);
            MasaInstance.transform.SetParent(ItemPosition);
            MasaInstance.transform.localPosition = Vector3.zero;
            hasMasa = true;

            StartCoroutine(ShowMessage("Recogiste masa", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PickUpCarnePicada()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {

            CarnePicadaInstance = Instantiate(CarnePicadaPrefab, ItemPosition.position, Quaternion.identity);
            CarnePicadaInstance.transform.SetParent(ItemPosition);
            CarnePicadaInstance.transform.localPosition = Vector3.zero;
            hasCarnePicada = true;

            StartCoroutine(ShowMessage("Tienes carne picada", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PickPlanchaMasa()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {

            PlanchaMasaInstance = Instantiate(PlanchaMasaPrefab, ItemPosition.position, Quaternion.identity);
            PlanchaMasaInstance.transform.SetParent(ItemPosition);
            PlanchaMasaInstance.transform.localPosition = Vector3.zero;
            hasPlanchaMasa = true;

            StartCoroutine(ShowMessage("Tienes plancha de masa", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PickUpTapas()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {

            TapasInstance = Instantiate(TapasPrefab, ItemPosition.position, Quaternion.identity);
            TapasInstance.transform.SetParent(ItemPosition);
            TapasInstance.transform.localPosition = Vector3.zero;
            hasTapas = true;

            StartCoroutine(ShowMessage("Tienes tapas de empanada", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PickUpEmpanadasCrudas()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {

            EmpanadasCrudasInstance = Instantiate(EmpanadasCrudasPrefab, ItemPosition.position, Quaternion.identity);
            EmpanadasCrudasInstance.transform.SetParent(ItemPosition);
            EmpanadasCrudasInstance.transform.localPosition = Vector3.zero;
            hasEmpanadasCrudas = true;

            StartCoroutine(ShowMessage("Tienes empanadas crudas", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PickUpEmpanadas()
    {
        if (!hasCarne && !hasMasa && !hasCarnePicada && !hasPlanchaMasa && !hasTapas && !hasEmpanadas && !hasEmpanadasCrudas)
        {

            EmpanadasInstance = Instantiate(EmpanadasPrefab, ItemPosition.position, Quaternion.identity);
            EmpanadasInstance.transform.SetParent(ItemPosition);
            EmpanadasInstance.transform.localPosition = Vector3.zero;
            hasEmpanadas = true;

            StartCoroutine(ShowMessage("Tienes empanadas", 2f));
        }
        else
        {
            StartCoroutine(ShowMessage("Tienes las manos ocupadas", 2f));
        }
    }

    public void PlaceCarnePicadaOnTable(Transform tablePosition)
    {
        if (hasCarnePicada)
        {
            Destroy(CarnePicadaInstance);

            GameObject CarneEnMesa = Instantiate(CarnePicadaPrefab, new Vector3(0,0,0), Quaternion.identity);
            CarneEnMesa.transform.SetParent(tablePosition);

            CarneEnMesa.transform.localPosition = new Vector3(.2f, .5f, 0f);
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

            TapasEnMesa.transform.localPosition = new Vector3(-.2f, .5f, 0f);
            TapasEnMesa.transform.localRotation = Quaternion.identity;


            hasTapas = false;
            StartCoroutine(ShowMessage("Tapas colocadas en la mesa", 2f));
        }
    }

    public void GiveEmpanadas()
    {
        if (hasEmpanadas)
        {
            Destroy(EmpanadasInstance);
            hasEmpanadas = false;

            StartCoroutine(ShowMessage("Empanadas entregadas", 2f));
        }
    }

    public void DiscardItem()
    {
        if (hasCarne || hasMasa || hasCarnePicada || hasPlanchaMasa || hasTapas || hasEmpanadas || hasEmpanadasCrudas)
        {
            Destroy(CarneInstance);
            Destroy(MasaInstance);
            Destroy(CarnePicadaInstance);
            Destroy(PlanchaMasaInstance);
            Destroy(TapasInstance);
            Destroy(EmpanadasInstance);
            Destroy(EmpanadasCrudasInstance);
            hasCarne = false;
            hasMasa = false;
            hasCarnePicada = false;
            hasPlanchaMasa = false;
            hasTapas = false;
            hasEmpanadas = false;
            hasEmpanadasCrudas = false;
        }
        else
        {
            StartCoroutine(ShowMessage("No tienes nada que descartar", 2f));
        }
    }

    public bool HasCarne()
    {
        return hasCarne;
    }

    public bool HasMasa()
    {
        return hasMasa;
    }

    public bool HasCarnePicada()
    {
        return hasCarnePicada;
    }

    public bool HasPlanchaMasa()
    {
        return hasPlanchaMasa;
    }

    public bool HasTapas()
    {
        return hasTapas;
    }

    public bool HasEmpanadas()
    {
        return hasEmpanadas;
    }

    public bool HasEmpanadasCrudas()
    {
        return hasEmpanadasCrudas;
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false);
    }
}
