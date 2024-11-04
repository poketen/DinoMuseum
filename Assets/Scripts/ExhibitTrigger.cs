using System.Collections;
using UnityEngine;

public class ExhibitTrigger : MonoBehaviour
{
    public AudioSource infoAudio; // Audio f?r die Ausstellungsinfo
    public AudioSource questionAudio; // Audio f?r die Frage
    public AudioSource yesAudioSource; // Audio f?r richtige Antwort
    public AudioSource noAudioSource; // Audio f?r falsche Antwort

    private bool isPlayerInRange = false;
    private bool questionAsked = false;




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !questionAsked)
        {
            Debug.Log("Player entered the trigger zone.");
            isPlayerInRange = true;
            PlayInfoAndQuestion();
        }
        // Finde den HeadMovementDetection-Skript und setze die aktuelle ExhibitTrigger-Referenz
        HeadMovementDetection headMovement = other.GetComponent<HeadMovementDetection>();
        if (headMovement != null)
        {
            headMovement.SetCurrentExhibitTrigger(this); // Setze die aktuelle ExhibitTrigger-Instanz
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            questionAsked = false;
        }
    }

    void PlayInfoAndQuestion()
    {
        if (infoAudio != null)
        {
            infoAudio.Play();
            Debug.Log("Info audio played.");
            StartCoroutine(PlayQuestionAfterDelay(infoAudio.clip.length)); // Frage-Audio nach der Info abspielen
        }
        else
        {
            Debug.LogWarning("Info audio is not assigned!");
        }
    }

    private IEnumerator PlayQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (questionAudio != null)
        {
            questionAudio.Play();
            Debug.Log("Question audio played.");
            questionAsked = true; // Frage wurde gestellt
        }
        else
        {
            Debug.LogWarning("Question audio is not assigned!");
        }
    }
}