using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class TriggerSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Hole die AudioSource-Komponente
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            Debug.LogWarning("Keine AudioSource-Komponente gefunden. Bitte fügen Sie eine AudioSource hinzu.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            // Sound abspielen
            audioSource.Play();
        }
    }
}