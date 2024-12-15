using UnityEngine;
using TMPro;

public class ClienteTutorial : MonoBehaviour
{
    public TextMeshPro pedidoTexto; // Referencia al texto del pedido
    private int empanadasPedidas = 1; // Pedido fijo de 1 empanada
    private int empanadasRecibidas = 0; // Empanadas entregadas

    private bool clienteAtendido = false;

    void Start()
    {
        ActualizarTextoPedido();
    }

    public bool RecibirEmpanada()
    {
        if (!clienteAtendido && empanadasRecibidas < empanadasPedidas)
        {
            empanadasRecibidas++;
            ActualizarTextoPedido();

            // Verifica si se completó el pedido
            if (empanadasRecibidas == empanadasPedidas)
            {
                clienteAtendido = true;
                Debug.Log("Cliente atendido correctamente.");
            }
            return true;
        }

        Debug.Log("Pedido ya completado o no válido.");
        return false;
    }

    private void ActualizarTextoPedido()
    {
        string texto = "";

        if (empanadasRecibidas < empanadasPedidas)
            texto += $"Empanada X{empanadasPedidas - empanadasRecibidas}\n";

        if (clienteAtendido)
            texto += "¡Gracias por atenderme!";

        pedidoTexto.text = texto;
    }
}
