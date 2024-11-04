using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
using UnityEngine;

public class HeadMovementDetection : MonoBehaviour
{
    public float nodThreshold = 20f; // Schwelle für Nicken
    public float shakeThreshold = 20f; // Schwelle für Kopfschütteln

    private ExhibitTrigger currentExhibitTrigger; // Referenz auf den aktuellen ExhibitTrigger
    private Vector3 lastRotation;

    void Start()
    {
        lastRotation = transform.eulerAngles;
    }

    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;
        Vector3 rotationDelta = currentRotation - lastRotation;

        // Nickbewegung erkennen (Veränderung in der X-Achse)
        if (Mathf.Abs(rotationDelta.x) > nodThreshold)
        {
            if (rotationDelta.x > 0)
            {
                Debug.Log("Nicken erkannt: JA");
                PlayResponseAudio(true); // Ja-Audio abspielen
            }
            else
            {
                Debug.Log("Kopfschütteln erkannt: NEIN");
                PlayResponseAudio(false); // Nein-Audio abspielen
            }
        }

        lastRotation = currentRotation;
    }

    public void SetCurrentExhibitTrigger(ExhibitTrigger exhibitTrigger)
    {
        currentExhibitTrigger = exhibitTrigger;
    }

    private void PlayResponseAudio(bool isYes)
    {
        if (currentExhibitTrigger != null)
        {
            // Wähle die AudioSource basierend auf der Antwort aus
            AudioSource responseAudio = isYes ? currentExhibitTrigger.yesAudioSource : currentExhibitTrigger.noAudioSource;
            if (responseAudio != null)
            {
                responseAudio.Play();
            }
        }
    }
}
*/
//Test ohne VR Brille

using UnityEngine;

public class HeadMovementDetection : MonoBehaviour
{
    public float nodThreshold = 20f; // Schwelle für Nicken
    public float shakeThreshold = 20f; // Schwelle für Kopfschütteln

    private ExhibitTrigger currentExhibitTrigger; // Referenz auf den aktuellen ExhibitTrigger
    private ExhibitTrigger2 currentExhibitTrigger2;
    private Vector3 lastRotation;

    void Start()
    {
        lastRotation = transform.eulerAngles;
    }

    void Update()
    {
        // Simuliere Kopfbewegungen mit der Tastatur
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SimulateNod(); // Simuliere Nicken
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SimulateShake(); // Simuliere Kopfschütteln
        }

        Vector3 currentRotation = transform.eulerAngles;
        Vector3 rotationDelta = currentRotation - lastRotation;

        // (Hier bleibt der ursprüngliche Code für die Erkennung von Nicken und Schütteln)

        lastRotation = currentRotation;
    }

    private void SimulateNod()
    {
        Debug.Log("Nicken erkannt: JA");
        PlayResponseAudio(true); // Ja-Audio abspielen
    }

    private void SimulateShake()
    {
        Debug.Log("Kopfschütteln erkannt: NEIN");
        PlayResponseAudio(false); // Nein-Audio abspielen
    }

    public void SetCurrentExhibitTrigger(ExhibitTrigger exhibitTrigger)
    {
        currentExhibitTrigger = exhibitTrigger;
    }

    public void SetCurrentExhibitTrigger2(ExhibitTrigger exhibitTrigger)
    {
        currentExhibitTrigger = exhibitTrigger;
    }

    private void PlayResponseAudio(bool isYes)
    {
        if (currentExhibitTrigger != null)
        {
            AudioSource responseAudio = isYes ? currentExhibitTrigger.yesAudioSource : currentExhibitTrigger.noAudioSource;
            if (responseAudio != null)
            {
                responseAudio.Play();
            }
        }
    }
}
