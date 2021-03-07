using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Walkman : MonoBehaviour
{
    private New_ZoneManager zoneManager;
    private ourZone zoneActuelle;



    public GameObject[] tapes;

    private GameObject currentTape;
    private GameObject lastTape;

    private AudioSource asource;
  

    // Start is called before the first frame update
    void Start()
    {
        zoneManager = GetComponent<New_ZoneManager>();
        zoneActuelle = New_ZoneManager.zoneActuelle;

        

    }

    void OnCollisionEnter(Collision collision)
    {
        // 2 - Si il n'y a pas de cassette dans le walkman, alors on met celle avec laquelle on est en collision.
        if (currentTape == null && collision.gameObject != lastTape)
        {
            foreach (GameObject tape in tapes)
            {
                //3.check if collision is a cassete 
                if (collision.gameObject.name == tape.name)
                {
                    // 2 - On définit la nouvelle cassette et on récupère certaines informations.
                    currentTape = collision.gameObject;

                    currentTape.GetComponent<Rigidbody>().isKinematic = true;
                    currentTape.transform.parent = this.transform.GetChild(0).transform;



                    //currentTape.transform.position = currentTape.transform.parent.transform.position;// new Vector3(0,0,0);// transform.position;// Vector3.zero;// currentTape.transform.parent.transform.localPosition;
                    currentTape.transform.localPosition = Vector3.zero;
                   
                    currentTape.transform.localRotation = currentTape.transform.parent.transform.rotation;

          

                    //currentTape.transform.localPosition = transform.position;// this.transform.position;
                    //currentTape.transform.rotation = this.transform.rotation;

                    // 2 - On lance la fonction (Coroutine) lié à l'action de la cassette dans le Walkman
                    Debug.Log(currentTape.name);
                    StartCoroutine("PlaySongCoroutine");
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // 2 - Si il n'y a pas de cassette dans le walkman, alors on met celle avec laquelle on est en collision.
        if (currentTape == null && other.gameObject != lastTape)
        {
            foreach (GameObject tape in tapes)
            {
                //3.check if collision is a cassete 
                if (other.gameObject.name == tape.name)
                {
                    // 2 - On définit la nouvelle cassette et on récupère certaines informations.
                    currentTape = other.gameObject;

                    currentTape.GetComponent<Rigidbody>().isKinematic = true;
                    currentTape.transform.parent = this.transform.GetChild(0).transform;



                    //currentTape.transform.position = currentTape.transform.parent.transform.position;// new Vector3(0,0,0);// transform.position;// Vector3.zero;// currentTape.transform.parent.transform.localPosition;
                    currentTape.transform.localPosition = Vector3.zero;

                    currentTape.transform.localRotation = currentTape.transform.parent.transform.rotation;



                    //currentTape.transform.localPosition = transform.position;// this.transform.position;
                    //currentTape.transform.rotation = this.transform.rotation;

                    // 2 - On lance la fonction (Coroutine) lié à l'action de la cassette dans le Walkman
                    Debug.Log(currentTape.name);
                    StartCoroutine("PlaySongCoroutine");
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // 2 - On réinitialise certaines informations lorsqu'on quitte la collision.
        if (collision.gameObject == lastTape)
        {
            lastTape = null;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == lastTape)
        {
            lastTape = null;
        }
    }




    IEnumerator PlaySongCoroutine()
    {
        Debug.Log("Song started !");
        switch (currentTape.name) // 2 - Cassette Actuelle  
        {
            // 2 - TODO :
            // En fonction du nom de la cassette, on joue la musique associé.
            // Le modèle est en dessous, il reste à le faire pour toutes les casettes.

            case "K7rock1989queen_2050":
     
                var musique = (AudioClip)Resources.Load<AudioClip>("Audio/Queen TheMiracle");
                 asource = tapes[2].GetComponent<AudioSource>();
                asource.clip = musique;
                
                break;

            case "K7future":
                AudioClip musiquefutur = (AudioClip)Resources.Load<AudioClip>("Audio/the-back-to-the-future");
                asource = tapes[1].GetComponent<AudioSource>();
                asource.clip = musiquefutur;
                break;
            case "K7farWest":
                AudioClip musiquewestern = (AudioClip)Resources.Load<AudioClip>("Audio/the-back-to-the-future");
                asource = tapes[0].GetComponent<AudioSource>();
                asource.clip = musiquewestern;
                break;
      

        }
        asource.Play();
        
        yield return new WaitForSeconds(5); 

        asource.Stop();
        Debug.Log("Song ended !");

        switch (currentTape.name)
        {
            case "K7rock1989queen_2050":
                zoneManager.GoToA();
                break;
            case "K7future":
                zoneManager.GoToB();
                break;
            case "K7farWest":
                zoneManager.GoToC();
                break;
        

        }
        // On éjecte la cassette du walkman
        currentTape.transform.parent = null;
        currentTape.GetComponent<Rigidbody>().isKinematic = false;
        lastTape = currentTape;
        currentTape = null;
        

    }

 
}
