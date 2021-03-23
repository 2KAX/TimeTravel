using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCassette : MonoBehaviour
{
    public static bool HasBeenPenned=false; // Variable permettant de savoir si la cassette a déjà été rembobinée
    private int layermask = 30;// Layer du Pencil
    private AudioSource Rembodio;//Audio du bruit de rembobinage
    void Start()
    {
        transform.parent.tag = "Untagged";
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(layermask);
        Debug.Log("Patate");
        Debug.Log(other.gameObject.layer);
        
        if (other.gameObject.layer == layermask)// On détecte le Crayon
        {
            if (!HasBeenPenned)
            {
                Debug.Log("PATATA");
                //On active la cassette en changeant son Tag
                transform.parent.tag = "K7future";
                var musique = (AudioClip)Resources.Load<AudioClip>("Audio/Rembobinage");
                Rembodio = transform.parent.GetComponent<AudioSource>();
                Rembodio.clip = musique;
                Rembodio.Play();
            }
            HasBeenPenned = true;
        }
    }
}
