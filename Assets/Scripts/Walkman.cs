using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkman : MonoBehaviour
{
    private ZoneManager zoneManager;
    private ourZone zoneActuelle;
    private GameObject currentTape;
    private AudioSource asource;
    private tiroir Tir;


  

    // Start is called before the first frame update
    void Start()
    {
        zoneManager = GetComponent<ZoneManager>();
        zoneActuelle = ZoneManager.zoneActuelle;
        switch (zoneActuelle)
        {
            case ourZone.eighties:
                Tir = GameObject.Find("drawer80s").GetComponent<tiroir>();
                break;
            case ourZone.fifties:
                Tir = GameObject.Find("drawer2050").GetComponent<tiroir>();
                break;
            case ourZone.Western:
                Tir = GameObject.Find("Triggertiroir").GetComponent<tiroir>();
                break;
        }
    }

  void OnCollisionEnter(Collision collision)
    {
        // 2 - Si il n'y a pas de cassette dans le walkman, alors on met celle avec laquelle on est en collision.
        if (currentTape == null)
        {

            if(collision.gameObject.tag == "K7future" || collision.gameObject.tag == "K7farWest" || collision.gameObject.tag == "K7rock1989queen_2050")
            {
                currentTape = collision.gameObject;

                currentTape.GetComponent<Rigidbody>().isKinematic = true;
                currentTape.transform.parent = this.transform.GetChild(0).transform;

                currentTape.transform.localPosition = Vector3.zero;
                currentTape.transform.localRotation = currentTape.transform.parent.localRotation;
                currentTape.transform.Rotate(Vector3.right, 90);
                //  On lance la fonction (Coroutine) lié à l'action de la cassette dans le Walkman
                Debug.Log(currentTape.name);
                StartCoroutine("PlaySongCoroutine");
            }
        }
    }
    


    IEnumerator PlaySongCoroutine()
    {
        Debug.Log("Song started !");
        switch (currentTape.tag) // 2 - Cassette Actuelle  
        {

            case "K7rock1989queen_2050":
     
                var musique = (AudioClip)Resources.Load<AudioClip>("Audio/Queen TheMiracle");
                 asource = currentTape.GetComponent<AudioSource>();
                 asource.clip = musique;
                if (!zoneManager.Used80) zoneManager.Used80 = true;
                break;

            case "K7future":
                AudioClip musiquefutur = (AudioClip)Resources.Load<AudioClip>("Audio/the-back-to-the-future");
                asource = currentTape.GetComponent<AudioSource>();
                asource.clip = musiquefutur;
                if (!zoneManager.Usedfutur) zoneManager.Usedfutur = true;
                break;

            case "K7farWest":
                AudioClip musiquewestern = (AudioClip)Resources.Load<AudioClip>("Audio/the_entertainment");
                asource = currentTape.GetComponent<AudioSource>();
                asource.clip = musiquewestern;
                if (!zoneManager.Usedwest) zoneManager.Usedwest = true;
                break;
      

        }
        asource.Play();
        
        yield return new WaitForSeconds(5); 

        asource.Stop();
        Debug.Log("Song ended !");

        if (zoneManager.Used80)
        {
            if (GameObject.Find("K7rock1989queen_2050(Clone)") != null)
            {
                DontDestroyOnLoad(GameObject.Find("K7rock1989queen_2050(Clone)"));
            }
        }
        if (zoneManager.Usedfutur)
        {
            DontDestroyOnLoad(GameObject.Find("K7future"));
        }
        if (zoneManager.Usedwest)
        {
            DontDestroyOnLoad(GameObject.Find("K7farWest"));
        }
        if (Tir.GoCont != null)//Dans le cas où la liste des objets contenus dans le tiroir est non nulle 
        {
            Tir.RemoveChild();// On enlève les enfants de certains GameObject contenu dans la liste pour éviter de leur supprimer leur parent
            foreach (GameObject go in Tir.GoCont)//On parcourt tous les objets, on set leurs parents à nul pour utiliser le DontDestroyOnLoad
            {
                go.transform.parent = null;// !!! ICI  !!! ça peut poser problème pour la TP de la cassette 80's qui dispose de trigger sur elle par exemple...
                DontDestroyOnLoad(go);
            }
        }
        Debug.Log(currentTape.name);
        switch (currentTape.tag)
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
        currentTape.transform.localPosition = new Vector3(0f, Random.Range(-1f, 1f), 1f);
        currentTape.transform.localRotation = Quaternion.Euler(Random.Range(2f,90f), 0f, Random.Range(2f, 70f));
        currentTape.transform.parent = null;
        
        currentTape.GetComponent<Rigidbody>().isKinematic = false;

        currentTape = null;

        
       

    }

 
}
