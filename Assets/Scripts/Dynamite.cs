using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2 - Ce script gère la classe Dynamite et les méthodes liées à cette classe.

public class Dynamite : WhenGrabbed
{
	public ParticleSystem fuseEffect; // 2 - Variable de l'effet de particule
	public string explodeOnTag; // 2 - Le tag de l'objet sur lequel la dynamite va exploser
    public GameObject explosionEffect;
    private bool fuseOn = false; // 2 - Si l'effect Particule est activé
    private Vector3 spawnLocation; // 2 - Le lieu de l'apparition de la dynamite

	private AudioSource firefuse;//3.audio fire fuse
	private AudioSource explosion; // 3. audio explosion

	public ControllerGrabObject hand;


	private void Start()
	{
		AudioSource[] audioSources = GetComponents<AudioSource>();
		firefuse =  audioSources[0];
		explosion = audioSources[1];
		spawnLocation = transform.position;
		//Invoke("Grab", 2f);
	}


    /// <summary>
    /// À appeler quand le joueur saisit l'objet
    /// </summary>

    // 2 - Cette fonction va lancer l'apparition de particule lorsqu'on attrape la dynamite 
    public override void Grab()
    {
		fuseEffect.Play();
		//3.active audio lors du saisi
		firefuse.enabled = true;
		
		fuseOn = true;
	}

    public override void Released()
    {
		return;
    }

    public void OnTriggerEnter(Collider other)
	{
		// 2 - Si collision avec le bon objet
		if (other.gameObject.CompareTag(explodeOnTag))
		{
			
			// 2 - Ça explose
			Explode();
            // 2 - On récupère la composante Fracturable du parent de l'objet qui collisionne
			Fracturable fracturable = other.GetComponent<Fracturable>();

			if (fracturable != null)
			{
                // 2 - On lance la méthode qui lance la fracture.
				fracturable.Fracture();
			}
		}
	}

	public void Explode()
	{
        // 2 - Fonction crée l'explosion
        Debug.Log("BOOM !");
		// 3.desactive audio lors de l'explosion
		firefuse.enabled = false;
		//3. lance audio explosion une fois
		explosion.enabled = true;
		explosion.PlayOneShot(explosion.clip);


		// 2 - Crée l'effet d'explosion
		GameObject exp = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        // 2 - On enlève cet effet au bout de 3s
        Destroy(exp, 3);
        // 2 - On respawn la dynamite
		Instantiate(gameObject, spawnLocation, Quaternion.identity);
		Destroy(gameObject);
	}
}
