using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject clientePrefab;
    public Transform[] posicionesFila;
    public float tiempoSpawn = 30f;
    public int limiteClientes = 3;

    private Queue<GameObject> filaClientes = new Queue<GameObject>();
    private float timerSpawn;
    private DatosJuego datosJuego;

    public TextMeshProUGUI propinaTexto;
    public int propinaTotal = 0;

    private void Start()
    {
        datosJuego = SistemaGuardado.CargarDatos();
        propinaTotal = datosJuego.propinasAcumuladas;
        propinaTexto.text = "Propina: $" + propinaTotal.ToString();
        timerSpawn = tiempoSpawn;
    }

    private void Update()
    {
        if (filaClientes.Count < limiteClientes)
        {
            timerSpawn += Time.deltaTime;

            if (timerSpawn >= tiempoSpawn)
            {
                SpawnCliente();
                timerSpawn = 0f;
            }
        }
    }

    private void SpawnCliente()
    {
        if (filaClientes.Count < limiteClientes)
        {
            GameObject nuevoCliente = Instantiate(clientePrefab, posicionesFila[filaClientes.Count].position, Quaternion.identity);
            Cliente clienteScript = nuevoCliente.GetComponent<Cliente>();
            clienteScript.AsignarPedido(Random.Range(0, 8));
            clienteScript.OnClienteEnojado += ClienteEnojado; // Subscribirse al evento
            filaClientes.Enqueue(nuevoCliente);
        }
    }

    private void ClienteEnojado(Cliente cliente)
    {
        if (filaClientes.Count > 0 && filaClientes.Peek().GetComponent<Cliente>() == cliente)
        {
            filaClientes.Dequeue();
            propinaTotal = Mathf.Max(0, propinaTotal - 10); // Reducir la propina
            propinaTexto.text = "Propina: $" + propinaTotal.ToString();
            Destroy(cliente.gameObject);
            ReorganizarFila();
        }
    }

    public bool EntregarItemAlCliente(string tipoItem, int valorItem)
    {
        if (filaClientes.Count > 0)
        {
            GameObject primerCliente = filaClientes.Peek();
            Cliente clienteScript = primerCliente.GetComponent<Cliente>();

            if (clienteScript.RecibirItem(tipoItem))
            {
                if (clienteScript.PedidoCompletado())
                {
                    float tiempoEspera = clienteScript.AtenderCliente();
                    CalcularPropina(tiempoEspera, valorItem);
                    clienteScript.OnClienteEnojado -= ClienteEnojado; // Desuscribirse del evento
                    filaClientes.Dequeue();
                    Destroy(primerCliente);
                    ReorganizarFila();
                }
                return true;
            }
        }
        return false;
    }

    private void ReorganizarFila()
    {
        int index = 0;
        foreach (GameObject cliente in filaClientes)
        {
            cliente.transform.position = posicionesFila[index].position;
            index++;
        }
    }

    private void CalcularPropina(float tiempoEspera, int valorItem)
    {
        int propina = Mathf.Max(0, valorItem - Mathf.RoundToInt(tiempoEspera));
        if (propina > 0)
        {
            propinaTotal += propina;
            propinaTexto.text = "Propina: $" + propinaTotal.ToString();
        }
    }
}