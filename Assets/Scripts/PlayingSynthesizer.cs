using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2 - Ce script gère le moment où le joueur joue sur le synthé.

public class PlayingSynthesizer : MonoBehaviour
{
    // 2 - Les Timers et booléen associé
    private float timerMusic = 0.0f;
    private bool TimerIsRunning = false;
    private bool FirstNotePlayed = false;

    // 2 - Les AudioClips (Clip)
    // TODO : On peut essayer de les récupérer de façon automatique dans le Start
    public AudioClip FirstNote; // 2 - La première note à jouer.
    public AudioClip Melody; // 2 - La mélodie qui sera jouée.

    public GameObject cassette; // 2 - Une cassette a faire apparaitre

    private AudioSource asr; // 2 - Une AudioSource associé au synthé.



    private void Start()
    {
        // 2 - On désactive la cassette (le GameObject)
        cassette.SetActive(false);
        // 2 - On récupère l'AudioSource du GameObject associé au script
        asr = GetComponent<AudioSource>();
        // 2 - On remplace son son
        asr.clip = FirstNote;
    }



    void Update()
    {
        if (TimerIsRunning)
        {
            // 2 - Si le timer est lancé alors on incrémente le timer.
            timerMusic += Time.deltaTime;
        }

        if (asr.clip == Melody && timerMusic > asr.clip.length)
        {
            // Faire poper la cassette
            cassette.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 2 - S'il y a collision entre le synthé et les mains du joueur.
        if (other.CompareTag("Player"))
        {
            if (asr.clip.length <= 2f && FirstNotePlayed)
            {
                asr.clip = Melody;
                timerMusic = 0;
            }
            asr.Play();
            TimerIsRunning = true;
            FirstNotePlayed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //S'il y avait collision entre le synthé et les mains du joueur.
        if (other.CompareTag("Player"))
        {
            //On met la mélodie en pause et on stoppe le timer
            asr.Pause();
            TimerIsRunning = false;
        }
    }
}
