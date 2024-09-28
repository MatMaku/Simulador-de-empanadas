using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteManager : MonoBehaviour
{
    public GameObject clientePrefab; // Prefab del cliente
    public Transform[] posicionesFila; // Posiciones para los clientes en la fila
    public float tiempoSpawn = 10f; // Tiempo entre la aparición de clientes
    public int limiteClientes = 3; // Límite de clientes en la fila

    private Queue<GameObject> filaClientes = new Queue<GameObject>(); // Cola de clientes
    private float timerSpawn;

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
    public void EntregarEmpanada()
    {
        if (filaClientes.Count > 0)
        {
            // Destruir el primer cliente en la fila
            GameObject primerCliente = filaClientes.Dequeue();
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
}