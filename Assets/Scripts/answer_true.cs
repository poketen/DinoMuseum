using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]

public class answer_true : MonoBehaviour
{
    public AudioSource ton;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;
    public question question;
    public String antwort=  "";
    // Start is called before the first frame update
    void Start()
    {
        question = GetComponent<question>();

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
        if (antwort == "rex")
        {
            audioSource1.Play();
        }else if(antwort == "")
        {
            audioSource2.Play();
        } else if(antwort == "egg")
        {
            audioSource3.Play();
        } else if (antwort == "velo")
        {
            audioSource4.Play();
        } else if (antwort == "komisch")
        {
            audioSource5.Play();
        } else if (antwort == "stego")
        {
            audioSource6.Play();
        }

    }
}
