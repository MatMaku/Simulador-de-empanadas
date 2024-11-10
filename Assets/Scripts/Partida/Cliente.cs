using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public int empanadasPedidas;
    public int bebidasPedidas;

    private int empanadasRecibidas = 0;
    private int bebidasRecibidas = 0;

    public TextMeshPro pedidoTexto;

    private bool clienteAtendido = false;
    public float tiempoEspera = 0;

    void Start()
    {
        ActualizarTextoPedido();
    }

    void Update()
    {
        if (!clienteAtendido)
        {
            tiempoEspera += Time.deltaTime;
        }
    }

    // Asigna el pedido aleatorio
    public void AsignarPedido(int tipoPedido)
    {
        switch (tipoPedido)
        {
            case 0:
                empanadasPedidas = 1;
                bebidasPedidas = 0;
                break;
            case 1:
                empanadasPedidas = 1;
                bebidasPedidas = 1;
                break;
            case 2:
                empanadasPedidas = 1;
                bebidasPedidas = 2;
                break;
        }
        ActualizarTextoPedido();
    }

    public bool RecibirItem(string tipoItem)
    {
        if (tipoItem == "empanada" && empanadasRecibidas < empanadasPedidas)
        {
            empanadasRecibidas++;
            ActualizarTextoPedido();
            return true;
        }
        else if (tipoItem == "bebida" && bebidasRecibidas < bebidasPedidas)
        {
            bebidasRecibidas++;
            ActualizarTextoPedido();
            return true;
        }

        // No recibir el item si no es necesario
        return false;
    }

    public bool PedidoCompletado()
    {
        return empanadasRecibidas == empanadasPedidas && bebidasRecibidas == bebidasPedidas;
    }

    public float AtenderCliente()
    {
        clienteAtendido = true;
        return tiempoEspera / 2;
    }

    private void ActualizarTextoPedido()
    {
        string texto = "";

        if (empanadasPedidas > empanadasRecibidas)
            texto += $"Empanadas X{empanadasPedidas - empanadasRecibidas}\n";

        if (bebidasPedidas > bebidasRecibidas)
            texto += $"Bebidas X{bebidasPedidas - bebidasRecibidas}";

        pedidoTexto.text = texto;
    }
}
