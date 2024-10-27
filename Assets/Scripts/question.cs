using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class question : MonoBehaviour
{
    private AudioSource audioSource;

    public Boolean answer = false;

    public String aName = "";

    private void Start()
    {
        // Hole die AudioSource-Komponente
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            Debug.LogWarning("Keine AudioSource-Komponente gefunden. Bitte fügen Sie eine AudioSource hinzu.");
        }
    }
    public Boolean getAnswer()
    {
        return answer;
    }

    public String getName()
    {
        return aName;
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