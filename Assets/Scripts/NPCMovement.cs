using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    public Transform[] waypoints;         // Array von Wegpunkten
    public float speed = 2.0f;            // Geschwindigkeit des NPCs
    public float[] waitTimes;             // Array von Wartezeiten für jeden Wegpunkt

    private int currentWaypointIndex = 0; // Aktueller Wegpunkt-Index
    private Animator animator;            // Animator-Referenz
    private bool isWaiting = false;       // Ob der NPC an einem Wegpunkt wartet

    void Start()
    {
        // Animator-Komponente abrufen
        animator = GetComponent<Animator>();

        // Startet Bewegung zum ersten Wegpunkt
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (waypoints.Length == 0 || isWaiting) return; // Überprüfen, ob es Wegpunkte gibt oder NPC wartet

        // Ziel-Wegpunkt festlegen
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;

        // NPC in Richtung des Wegpunkts drehen
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }

        // Bewegen Sie den NPC nur, wenn er den Wegpunkt noch nicht erreicht hat
        if (Vector3.Distance(transform.position, targetWaypoint.position) > 0.1f)
        {
            // NPC zu dem aktuellen Wegpunkt bewegen
            transform.position += direction * speed * Time.deltaTime;
            
            // Animation aktivieren
            animator.SetBool("walk", true);
        }
        else
        {
            // Stoppe die Animation, wenn der NPC das Ziel erreicht hat
            animator.SetBool("walk", false);

            // Starte die Wartezeit am aktuellen Wegpunkt
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true; // Setze den NPC in den Wartemodus

        // Warte für die festgelegte Zeit am aktuellen Wegpunkt
        yield return new WaitForSeconds(waitTimes[currentWaypointIndex]);

        // Nächsten Wegpunkt auswählen und Bewegung fortsetzen
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isWaiting = false; // Beenden des Wartens
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length > 0)
        {
            isWaiting = false;
            animator.SetBool("walk", true); // Setze Animation, wenn die Bewegung beginnt
        }
    }
}