using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array von Wegpunkten
    public float speed = 2.0f;    // Geschwindigkeit des NPCs
    private int currentWaypointIndex = 0; // Aktueller Wegpunkt-Index
    private Animator animator;     // Animator-Referenz

    void Start()
    {
        // Animator-Komponente abrufen
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (waypoints.Length == 0) return; // Überprüfen, ob es Wegpunkte gibt

        // Ziel-Wegpunkt festlegen
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // NPC in Richtung des Wegpunkts drehen
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }

        // NPC zu dem aktuellen Wegpunkt bewegen
        transform.position += direction * speed * Time.deltaTime;

        // Animation aktivieren
        animator.SetBool("walking", true);

        // Überprüfen, ob der NPC den Wegpunkt erreicht hat
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; // Nächsten Wegpunkt auswählen
        }
    }
}