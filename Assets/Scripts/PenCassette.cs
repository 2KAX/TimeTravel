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
        if (other.gameObject.layer == layermask)// On détecte le Crayon
        {
            if (!HasBeenPenned)
            {
                //On active la cassette en changeant son Tag
                transform.parent.tag = "K7rock1989queen_2050";
                var musique = (AudioClip)Resources.Load<AudioClip>("Audio/Rembobinage");//On joue le bruit de rembobinage
                Rembodio = transform.parent.GetComponent<AudioSource>();
                Rembodio.clip = musique;
                Rembodio.Play();
            }
            HasBeenPenned = true;//On empêche de retourner dans la boucle
        }
    }
}
