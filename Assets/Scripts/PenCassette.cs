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
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layermask)// On détecte le Crayon
        {
            if (!HasBeenPenned)
            {
                //On active la cassette en changeant son Tag
                transform.tag = "K7present";
                AudioClip musique = Resources.Load<AudioClip>("Audio/Rembobinage");//On joue le bruit de rembobinage
                Rembodio = transform.GetComponent<AudioSource>();
                Rembodio.clip = musique;
                Rembodio.Play();
            }
            HasBeenPenned = true;//On empêche de retourner dans la boucle
        }
    }
}
