using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClienteManager : MonoBehaviour
{
    public GameObject clientePrefab;
    public Transform[] posicionesFila;
    public float tiempoSpawn = 30f;
    public int limiteClientes = 3;

    private Queue<GameObject> filaClientes = new Queue<GameObject>();
    private float timerSpawn;

    public TextMeshProUGUI propinaTexto;
    private int propinaTotal = 0;

    void Update()
    {
        // Controlar el tiempo para spawnear nuevos clientes
        timerSpawn += Time.deltaTime;
        if (timerSpawn >= tiempoSpawn && filaClientes.Count < limiteClientes)
        {
            SpawnCliente();
            timerSpawn = 0f;
        }
    }

    // Método para instanciar un cliente y añadirlo a la fila
    void SpawnCliente()
    {
        GameObject nuevoCliente = Instantiate(clientePrefab, posicionesFila[filaClientes.Count].position, Quaternion.identity);
        filaClientes.Enqueue(nuevoCliente);
    }

    // Método para eliminar el primer cliente y mover los demás hacia adelante
    public void EntregarEmpanada(int ValorEmpanadas)
    {
        if (filaClientes.Count > 0)
        {
            // Obtener el primer cliente en la fila
            GameObject primerCliente = filaClientes.Dequeue();

            // Calcular el tiempo de espera del cliente y la propina
            float tiempoEspera = primerCliente.GetComponent<Cliente>().AtenderCliente();
            CalcularPropina(tiempoEspera, ValorEmpanadas);

            // Destruir el cliente
            Destroy(primerCliente);

            // Mover los demás clientes hacia adelante
            int index = 0;
            foreach (GameObject cliente in filaClientes)
            {
                cliente.transform.position = posicionesFila[index].position;
                index++;
            }
        }
    }

    void CalcularPropina(float tiempoEspera, int ValorEmpanadas)
    {
        int propina = Mathf.Max(0, ValorEmpanadas - Mathf.RoundToInt(tiempoEspera));
        propinaTotal += propina;
        propinaTexto.text = "Propina: $" + propinaTotal.ToString();
    }
}