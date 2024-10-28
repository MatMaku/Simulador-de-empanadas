using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void IniciarPartida()
    {
        SistemaGuardado.BorrarDatos();
        SceneManager.LoadScene("Juego");
    }

    public void ContinuarPartida()
    {
        DatosJuego datos = SistemaGuardado.CargarDatos();
        if (datos.diaActual > 1 || datos.propinasAcumuladas > 0)
        {
            SceneManager.LoadScene("Juego");
        }
        else
        {
            Debug.Log("No hay partida guardada.");
        }
    }

    public void JugarTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
