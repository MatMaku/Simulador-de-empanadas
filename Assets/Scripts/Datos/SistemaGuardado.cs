using System.IO;
using UnityEngine;

public class SistemaGuardado
{
    private static string rutaArchivo = Application.persistentDataPath + "/datosJuego.json";

    // M�todo para guardar los datos del juego
    public static void GuardarDatos(DatosJuego datos)
    {
        string json = JsonUtility.ToJson(datos);
        File.WriteAllText(rutaArchivo, json);
        Debug.Log("Datos guardados en " + rutaArchivo);
    }

    // M�todo para cargar los datos del juego
    public static DatosJuego CargarDatos()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            DatosJuego datos = JsonUtility.FromJson<DatosJuego>(json);
            return datos;
        }
        else
        {
            // Si no hay archivo guardado, comenzamos desde cero
            Debug.Log("No se encontr� archivo de guardado, iniciando nuevo juego.");
            return new DatosJuego(1, 0); // D�a 1 y propinas 0
        }
    }

    // M�todo para eliminar los datos (para nueva partida)
    public static void BorrarDatos()
    {
        if (File.Exists(rutaArchivo))
        {
            File.Delete(rutaArchivo);
            Debug.Log("Datos borrados.");
        }
    }
}
