using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDia : MonoBehaviour
{
    public float tiempoDia = 120f;
    public GameManager gameManager;
    private float tiempoRestante;
    private DatosJuego datosJuego;

    public TextMeshProUGUI tiempoTexto;
    public TextMeshProUGUI diaTexto;

    void Start()
    {
        datosJuego = SistemaGuardado.CargarDatos();
        tiempoRestante = tiempoDia;
        diaTexto.text = "Dia: " + Convert.ToString(datosJuego.diaActual);
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        tiempoTexto.text = "Tiempo: " + Convert.ToInt32(tiempoRestante);

        if (tiempoRestante <= 0)
        {
            TerminarDia();
        }
    }

    void TerminarDia()
    {
        int propinasDelDia = gameManager.propinaTotal;
        datosJuego.propinasAcumuladas += propinasDelDia;

        datosJuego.diaActual++;
        SistemaGuardado.GuardarDatos(datosJuego);

        SceneManager.LoadScene("ResumenDia");
    }
}
