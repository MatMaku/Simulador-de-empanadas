using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI mensajeTutorial;
    public Image Background;
    public float tiempoMensaje = 3f;
    private int tareaActual = 0;
    private bool tutorialTerminado = false;

    private ItemHandler itemHandler;
    private ObjectInteraction objectInteraction;
    private GameManager clienteManager;

    [HideInInspector]public string[] mensajes = 
        {
        "¡Bienvenido al tutorial!",
        "Para empezar recoge algo de carne de la heladera",
        "Ahora cortala en la tabla de cortar",
        "Perfecto, ahora dejala en la mesa de preparado y encarguemonos de la masa",
        "Recoge un bollo de masa, estan en la heladera",
        "Ahora amasemoslo en la tabla de amasar",
        "Y por ultimo cortemos las tapas en la cortadora",
        "Ahora junta todo en la mesa de preparado",
        "Muy bien, ahora solo queda cocinarlas, metelas en el horno y espera",
        "Ahora entregalas al cliente y habremos terminado",
        "¡Felicidades, has terminado el tutorial, ya puedes jugar libremente!"
        };

    void Start()
    {
        itemHandler = FindObjectOfType<ItemHandler>();
        objectInteraction = FindObjectOfType<ObjectInteraction>();

        StartCoroutine(MostrarMensajeBienvenida());
    }

    IEnumerator MostrarMensajeBienvenida()
    {
        mensajeTutorial.text = mensajes[0];
        yield return new WaitForSeconds(tiempoMensaje);
        SiguienteTarea();
    }

    private void Update()
    {
        if (tareaActual == 1)
        {
            if (itemHandler.hasCarne)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 2)
        {
            if (itemHandler.hasCarnePicada)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 2)
        {
            if (itemHandler.hasCarnePicada)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 3)
        {
            if (objectInteraction.CarneOnTable)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 4)
        {
            if (itemHandler.hasMasa)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 5)
        {
            if (itemHandler.hasPlanchaMasa)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 6)
        {
            if (itemHandler.hasTapas)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 7)
        {
            if (itemHandler.hasEmpanadasCarneCrudas)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 8)
        {
            if (itemHandler.hasEmpanadasCarne)
            {
                SiguienteTarea();
            }
        }

        if (tareaActual == 9)
        {
            if (itemHandler.PrimerClienteAtendido)
            {
                SiguienteTarea();
            }
        }
    }

    public void SiguienteTarea()
    {
        if (tareaActual < mensajes.Length - 2)
        {
            tareaActual++;
            mensajeTutorial.text = mensajes[tareaActual];
        }
        else if (!tutorialTerminado)
        {
            tutorialTerminado = true;
            StartCoroutine(MostrarMensajeFinal());
        }
    }

    IEnumerator MostrarMensajeFinal()
    {
        mensajeTutorial.text = mensajes[mensajes.Length - 1];
        yield return new WaitForSeconds(tiempoMensaje);

        SceneManager.LoadScene("MenuInicio");
    }
}
