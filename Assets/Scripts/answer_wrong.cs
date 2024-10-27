using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]

public class answer_wrong : MonoBehaviour
{
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private question question;
    private Boolean antwort= false;
    // Start is called before the first frame update
    void Start()
    {
        question = GetComponent<question>();
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();

        if (audioSource1 == null)
        {
            Debug.LogWarning("Keine AudioSource1-Komponente gefunden. Bitte fügen Sie eine AudioSource hinzu.");
        }
        if (audioSource2 == null)
        {
            Debug.LogWarning("Keine AudioSource2-Komponente gefunden. Bitte fügen Sie eine AudioSource hinzu.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        antwort = question.getAnswer();
        if (antwort == false)
        {
            audioSource1.Play();
        }
        else
        {
            audioSource2.Play();
        }
    }
}
