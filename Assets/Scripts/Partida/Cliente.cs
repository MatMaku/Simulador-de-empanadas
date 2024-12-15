using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public int empanadasPedidas = 0;
    public int bebidasPedidas = 0;
    public int empanadasJyQPedidas = 0;
    public int pizzasPedidas = 0;

    private int empanadasRecibidas = 0;
    private int bebidasRecibidas = 0;
    private int empanadasJyQRecibidas = 0;
    private int pizzasRecibidas = 0;

    public TextMeshPro pedidoTexto;

    private bool clienteAtendido = false;
    public float tiempoEspera = 0;
    public float pacienciaMaxima = 60f; // Tiempo máximo para esperar el pedido
    private float pacienciaRestante;

    public System.Action<Cliente> OnClienteEnojado; // Evento para notificar que un cliente se enojó

    void Start()
    {
        pacienciaRestante = pacienciaMaxima;
        ActualizarTextoPedido();
    }

    void Update()
    {
        if (!clienteAtendido)
        {
            tiempoEspera += Time.deltaTime;
            pacienciaRestante -= Time.deltaTime;

            ActualizarTextoPedido();

            // Si la paciencia se agota, el cliente se va enojado
            if (pacienciaRestante <= 0)
            {
                OnClienteEnojado?.Invoke(this);
            }
        }
    }

    public void AsignarPedido(int tipoPedido)
    {
        switch (tipoPedido)
        {
            case 0:
                empanadasPedidas = 1;
                break;
            case 1:
                empanadasPedidas = 1;
                bebidasPedidas = 1;
                break;
            case 2:
                empanadasPedidas = 1;
                bebidasPedidas = 2;
                break;
            case 3:
                empanadasJyQPedidas = 1;
                bebidasPedidas = 1;
                break;
            case 4:
                empanadasJyQPedidas = 1;
                bebidasPedidas = 2;
                break;
            case 5:
                pizzasPedidas = 1;
                break;
            case 6:
                pizzasPedidas = 1;
                bebidasPedidas = 1;
                break;
            case 7:
                pizzasPedidas = 1;
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
        else if (tipoItem == "empanadaJyQ" && empanadasJyQRecibidas < empanadasJyQPedidas)
        {
            empanadasJyQRecibidas++;
            ActualizarTextoPedido();
            return true;
        }
        else if (tipoItem == "pizza" && pizzasRecibidas < pizzasPedidas)
        {
            pizzasRecibidas++;
            ActualizarTextoPedido();
            return true;
        }

        return false;
    }

    public bool PedidoCompletado()
    {
        return empanadasRecibidas == empanadasPedidas &&
               bebidasRecibidas == bebidasPedidas &&
               empanadasJyQRecibidas == empanadasJyQPedidas &&
               pizzasRecibidas == pizzasPedidas;
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
            texto += $"Empanadas carne X{empanadasPedidas - empanadasRecibidas}\n";

        if (bebidasPedidas > bebidasRecibidas)
            texto += $"Bebida X{bebidasPedidas - bebidasRecibidas}\n";

        if (empanadasJyQPedidas > empanadasJyQRecibidas)
            texto += $"Empanadas JyQ X{empanadasJyQPedidas - empanadasJyQRecibidas}\n";

        if (pizzasPedidas > pizzasRecibidas)
            texto += $"Pizza X{pizzasPedidas - pizzasRecibidas}\n";

        texto += $"Paciencia: {Mathf.CeilToInt(pacienciaRestante)}s";
        pedidoTexto.text = texto;
    }
}