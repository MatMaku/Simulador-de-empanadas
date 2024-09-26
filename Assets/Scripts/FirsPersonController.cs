using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirsPersonController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float mouseSensitivity = 2f; // Sensibilidad del mouse
    public Transform playerCamera; // Referencia a la cámara
    public float jumpHeight = 1.5f; // Altura de salto
    public float gravity = -9.81f; // Gravedad

    private CharacterController controller;
    private Vector3 velocity;
    private float xRotation = 0f; // Rotación de la cámara en el eje X
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
            // Movimiento de la cámara
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Limitar el ángulo de visión hacia arriba/abajo
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

            // Movimiento del jugador con WASD
            float moveX = Input.GetAxis("Horizontal"); // A/D
            float moveZ = Input.GetAxis("Vertical"); // W/S

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            controller.Move(move * speed * Time.deltaTime);

            // Verificar si está en el suelo
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Mantener al personaje en el suelo
            }

            // Aplicar gravedad
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
    }
}
