using UnityEngine;

public class ExhibitAudioManager : MonoBehaviour
{
    public AudioSource audioSource;  // Eine einzige AudioSource für die Wiedergabe

    public AudioClip defaultYesClip;  // Standard-„Ja“-Clip
    public AudioClip defaultNoClip;   // Standard-„Nein“-Clip

    private AudioClip currentYesClip;
    private AudioClip currentNoClip;

    private float nodThreshold = 15f;
    private float shakeThreshold = 15f;
    private bool isNodding = false;
    private bool isShaking = false;

    // Diese Methode wird aufgerufen, wenn der Benutzer einen neuen Exponat-Bereich betritt
    public void SetCurrentExhibitAudio(AudioClip yesClip, AudioClip noClip)
    {
        currentYesClip = yesClip;
        currentNoClip = noClip;
    }

    private void Update()
    {
        DetectHeadMovement();
    }

    private void DetectHeadMovement()
    {
        Vector3 headRotation = transform.eulerAngles;
        Debug.Log($"Head Rotation X: {headRotation.x} | Head Rotation Y: {headRotation.y}");

        // Nicken-Erkennung
        if (headRotation.x > nodThreshold && !isNodding)
        {
            Debug.Log("JA!");
            isNodding = true;
            PlayYesAudio();
        }
        else if (headRotation.x < -nodThreshold && !isNodding)
        {
            Debug.Log("JA!");
            isNodding = true;
            PlayYesAudio();
        }
        else
        {
            isNodding = false;
        }

        // Kopfschütteln-Erkennung
        if (headRotation.y > shakeThreshold && !isShaking)
        {
            Debug.Log("NO!");
            isShaking = true;
            PlayNoAudio();
        }
        else if (headRotation.y < -shakeThreshold && !isShaking)
        {
            Debug.Log("NO!");
            isShaking = true;
            PlayNoAudio();
        }
        else
        {
            isShaking = false;
        }
    }

    private void PlayYesAudio()
    {
        if (audioSource != null)
        {
            audioSource.clip = currentYesClip != null ? currentYesClip : defaultYesClip;
            audioSource.Play();
        }
    }

    private void PlayNoAudio()
    {
        if (audioSource != null)
        {
            audioSource.clip = currentNoClip != null ? currentNoClip : defaultNoClip;
            audioSource.Play();
        }
    }
}
