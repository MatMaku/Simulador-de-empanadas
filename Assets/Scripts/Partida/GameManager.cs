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
        timerSpawn = tiempoSpawn; // Iniciar el temporizador en el valor de tiempo de spawn para que comience inmediatamente
    }

    private void Update()
    {
        // Solo crear clientes si el número actual en la fila es menor que el límite
        if (filaClientes.Count < limiteClientes)
        {
            timerSpawn += Time.deltaTime;

            // Instanciar un cliente cuando se cumpla el tiempo
            if (timerSpawn >= tiempoSpawn)
            {
                SpawnCliente();
                timerSpawn = 0f;
            }
        }
    }

    // Método para instanciar un cliente y añadirlo a la fila
    private void SpawnCliente()
    {
        // Crear el cliente solo si hay espacio en la fila
        if (filaClientes.Count < limiteClientes)
        {
            GameObject nuevoCliente = Instantiate(clientePrefab, posicionesFila[filaClientes.Count].position, Quaternion.identity);
            nuevoCliente.GetComponent<Cliente>().AsignarPedido(Random.Range(0, 3)); // Asigna un pedido aleatorio
            filaClientes.Enqueue(nuevoCliente);
        }
    }

    // Método para eliminar el primer cliente y mover los demás hacia adelante
    public bool EntregarItemAlCliente(string tipoItem, int valorItem)
    {
        if (filaClientes.Count > 0)
        {
            GameObject primerCliente = filaClientes.Peek();
            Cliente clienteScript = primerCliente.GetComponent<Cliente>();

            // Verificar si el cliente necesita el ítem
            if (clienteScript.RecibirItem(tipoItem))
            {
                // Si el pedido está completado, eliminamos el cliente de la fila
                if (clienteScript.PedidoCompletado())
                {
                    float tiempoEspera = clienteScript.AtenderCliente();
                    CalcularPropina(tiempoEspera, valorItem);
                    filaClientes.Dequeue();
                    Destroy(primerCliente);
                    ReorganizarFila();
                }
                return true; // Ítem fue aceptado
            }
        }
        return false; // Ítem no fue necesario
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