using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Geschwindigkeit des Vorwärts- und Rückwärtslaufens
    public float moveSpeed = 5f;
    
    // Rotationsgeschwindigkeit
    public float rotationSpeed = 100f;

    // Referenz für den Rigidbody
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody-Komponente des Spielers holen
        rb = GetComponent<Rigidbody>();

        // Sicherstellen, dass das Rigidbody nicht umkippt
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Vorwärts- und Rückwärtsbewegung (W = vorwärts, S = rückwärts)
        float moveZ = Input.GetAxis("Vertical");

        // Drehung um die Y-Achse (A = links, D = rechts)
        float rotateY = Input.GetAxis("Horizontal");

        // Rotation um die Y-Achse
        transform.Rotate(0, rotateY * rotationSpeed * Time.deltaTime, 0);

        // Bewegung entlang der Z-Achse (falls der Kegel zur Seite zeigt, wird transform.right verwendet)
        Vector3 move = transform.right * moveZ * moveSpeed * Time.deltaTime;

        // Spieler bewegen
        rb.MovePosition(transform.position + move);
    }
}