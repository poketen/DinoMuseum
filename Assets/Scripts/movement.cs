using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Geschwindigkeit des Vorwärts- und Rückwärtslaufens
    public float moveSpeed = 25f;

    // Rotationsgeschwindigkeit für Tastenbewegung
    public float rotationSpeed = 100f;

    // Sensibilität für die Mausbewegung
    public float mouseSensitivity = 2f;

    // Maximale und minimale Rotation in der Vertikalen
    public float minYRotation = -60f;
    public float maxYRotation = 60f;

    // Referenz für den Rigidbody
    private Rigidbody rb;

    // Variable zur Speicherung der vertikalen Rotationsachse der Kamera
    private float verticalRotation = 0f;

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

        // Rotation um die Y-Achse durch Tasteneingabe
        transform.Rotate(0, rotateY * rotationSpeed * Time.deltaTime, 0);

        // Bewegung entlang der Z-Achse
        Vector3 move = transform.right * moveZ * moveSpeed * Time.deltaTime;

        // Spieler bewegen
        rb.MovePosition(transform.position + move);

        // Kamera mit der Maus drehen, wenn die linke Maustaste gehalten wird
        if (Input.GetMouseButton(0))
        {
            // Mausbewegung erfassen
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Drehung um die Y-Achse (horizontal) anwenden
            transform.Rotate(0, mouseX, 0);

            // Vertikale Rotation berechnen und einschränken
            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, minYRotation, maxYRotation);

            // Vertikale Rotation anwenden
            Camera.main.transform.localEulerAngles = new Vector3(verticalRotation, Camera.main.transform.localEulerAngles.y, 0);
        }
    }
}