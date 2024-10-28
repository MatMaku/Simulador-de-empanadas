using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniJuego1 : MonoBehaviour
{
    public FirsPersonController playerController;
    public ObjectInteraction objectInteraction;
    public ItemHandler itemHandler;

    public Slider cuttingProgressBar;
    public GameObject PushButton;
    public TextMeshProUGUI PushButtonText;
    public float progressPerPress = 0.1f;
    private bool isCutting = false;

    private KeyCode selectedKey;
    private DatosJuego datosJuego;

    private void Start()
    {
        datosJuego = SistemaGuardado.CargarDatos();
    }

    private List<KeyCode> possibleKeys = new List<KeyCode>
    {
        KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.R, KeyCode.F
    };

    void Update()
    {
        if (isCutting)
        {
            // Aumentar la barra solo cuando se pulsa la tecla "E"
            if (Input.GetKeyDown(selectedKey))
            {
                cuttingProgressBar.value += progressPerPress;
            }

            // Asegurarse de que el valor no exceda el máximo
            cuttingProgressBar.value = Mathf.Clamp(cuttingProgressBar.value, 0f, cuttingProgressBar.maxValue);

            // Comprobar si la barra está completamente llena
            if (cuttingProgressBar.value >= cuttingProgressBar.maxValue)
            {
                MinigameComplete();
            }
        }
    }

    public void StartMinigame()
    {
        if (itemHandler.hasCarne && datosJuego.MejoraCuchillo)
        {
            progressPerPress = 0.3f;
        }
        else if (itemHandler.hasMasa && datosJuego.MejoraPalo)
        {
            progressPerPress = 0.3f;
        }
        else
        {
            progressPerPress = 0.1f;
        }

        selectedKey = possibleKeys[Random.Range(0, possibleKeys.Count)];
        PushButtonText.text = selectedKey.ToString();

        isCutting = true;
        PushButton.SetActive(true);
        cuttingProgressBar.gameObject.SetActive(true);
        cuttingProgressBar.value = 0;

        playerController.enabled = false;

        PulseEffect pulseEffect = PushButton.GetComponent<PulseEffect>();
        pulseEffect.StartPulse();
    }

    private void MinigameComplete()
    {
        isCutting = false;
        PushButton.SetActive(false);
        cuttingProgressBar.gameObject.SetActive(false);

        playerController.enabled = true;
        objectInteraction.Interacting = false;

        PulseEffect pulseEffect = PushButton.GetComponent<PulseEffect>();
        pulseEffect.StopPulse();

        Debug.Log("Corte completado!");

        if (itemHandler.hasCarne)
        {
            itemHandler.DiscardItem();
            itemHandler.PickUpCarnePicada();
        }

        if (itemHandler.hasMasa)
        {
            itemHandler.DiscardItem();
            itemHandler.PickPlanchaMasa();
        }
    }
}
