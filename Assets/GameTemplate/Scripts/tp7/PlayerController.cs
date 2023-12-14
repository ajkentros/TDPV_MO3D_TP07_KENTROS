using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    public float rotationSpeed = 180f;
    public float jumpForce = 80f;
    public Transform isCamera;  // Asigna la c�mara al inspector

    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = speed * Time.deltaTime * new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement);

        // Rotaci�n
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(mouseX * rotationSpeed * Time.deltaTime * Vector3.up);

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Actualizar la posici�n de la c�mara
        isCamera.position = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador est� en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Objetos"))
        {
            Debug.Log("colisi�n con: " +  collision.gameObject.name);
        }
    }

}
