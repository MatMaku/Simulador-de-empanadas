using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public float tiempoEspera = 0;
    private bool clienteAtendido = false;

    void Update()
    {
        if (!clienteAtendido)
        {
            tiempoEspera += Time.deltaTime;
        }
    }

    public float AtenderCliente()
    {
        clienteAtendido = true;
        return tiempoEspera / 2;
    }
}
