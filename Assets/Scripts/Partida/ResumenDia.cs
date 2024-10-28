using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResumenDia : MonoBehaviour
{
    public TextMeshProUGUI textoDia;
    public TextMeshProUGUI textoPropina;
    public Button botonContinuar;
    public Button botonMejoras;
    public Button botonVolverResumen;

    public Button botonMejoraVelocidad;
    public Button botonMejoraCuchillo;
    public Button botonMejoraPalo;

    public GameObject panelResumen;
    public GameObject panelMejoras;

    private DatosJuego datosJuego;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        datosJuego = SistemaGuardado.CargarDatos();

        textoDia.text = "Día " + datosJuego.diaActual;
        textoPropina.text = "Propinas Acumuladas: $" + datosJuego.propinasAcumuladas.ToString();

        botonContinuar.onClick.AddListener(ContinuarAlSiguienteDia);
        botonMejoras.onClick.AddListener(AbrirMenuMejoras);
        botonVolverResumen.onClick.AddListener(VolverAlResumen);

        botonMejoraVelocidad.onClick.AddListener(() => ComprarMejora("Cocina", 150));
        botonMejoraCuchillo.onClick.AddListener(() => ComprarMejora("Cuchillo", 100));
        botonMejoraPalo.onClick.AddListener(() => ComprarMejora("Palo", 100));

        if (datosJuego.MejoraCocina)
        {
            botonMejoraVelocidad.interactable = false;
        }

        if (datosJuego.MejoraCuchillo)
        {
            botonMejoraCuchillo.interactable = false;
        }

        if (datosJuego.MejoraPalo)
        {
            botonMejoraPalo.interactable = false;
        }

        panelMejoras.SetActive(false);
    }

    void AbrirMenuMejoras()
    {
        panelResumen.SetActive(false);
        panelMejoras.SetActive(true);
    }

    void VolverAlResumen()
    {
        panelMejoras.SetActive(false);
        panelResumen.SetActive(true); 
    }

    void ComprarMejora(string tipo, int costo)
    {
        if (datosJuego.propinasAcumuladas >= costo)
        {
            datosJuego.propinasAcumuladas -= costo;
            switch (tipo)
            {
                case "Cocina":
                    datosJuego.MejoraCocina = true;
                    botonMejoraVelocidad.interactable = false; 
                    break;
                case "Cuchillo":
                    datosJuego.MejoraCuchillo = true;
                    botonMejoraCuchillo.interactable = false;
                    break;
                case "Palo":
                    datosJuego.MejoraPalo = true;
                    botonMejoraPalo.interactable = false;
                    break;
            }

            textoPropina.text = "Propinas Acumuladas: $" + datosJuego.propinasAcumuladas;
            SistemaGuardado.GuardarDatos(datosJuego);
        }
        else
        {
            Debug.Log("No tienes suficiente dinero para comprar esta mejora.");
        }
    }

    void ContinuarAlSiguienteDia()
    {
        SceneManager.LoadScene("Juego");
    }
}
