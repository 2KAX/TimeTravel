using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvrirCoffre : MonoBehaviour
{
    public Animation anim;
    private AudioSource asource;

    private void Start()
    {
        //anim = gameObject.GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //on déclenche l'animation d'ouverture du coffre lorsqu'il y a collision avec la clef
        if(other.tag == "Key")
        {
            AudioClip grincement = (AudioClip)Resources.Load<AudioClip>("Audio/chest_open");
            asource = gameObject.GetComponent<AudioSource>();
            asource.clip = grincement;
            asource.Play();
            anim.Play();

            Destroy(other.gameObject);
            //Destroy(this.gameObject); // While we don't have the animation
        }
    }
}
