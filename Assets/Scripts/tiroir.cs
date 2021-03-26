using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 2 - Ce script gère l'utilité du tiroir
// Il suit le joueur à travers le dimension et garde les cassettes qui dans les différents tiroirs.

public class tiroir : MonoBehaviour
{
    // 2 - Liste des autres tiroirs 
    public tiroir[] autresTiroirs;
    // 2 - Variables qui contrôle la zone dans laquelle on est.
    public ZoneManager zm;
    public static List<GameObject> GoContained = new List<GameObject>(); //Liste des gameObject contenus dans le tiroir
    public ourZone zoneTiroir;
    public List<GameObject> GoCont
    {
        get{ return GoContained; }
    }
    public void Awake()//Lors du lancement d'une autre scène on lance le Awake afin de "TP" les objets contenus dans le tiroir
    {
        foreach(GameObject Go in GoContained)
        {
            DestroyandCreate(Go);
        }
        GoContained.Clear();//On clear la Liste une fois que tous les éléments ont été ajouté dans la scène

    }
    public void DestroyandCreate(GameObject Go)//Permet au lancement du Awake de créer un clone de l'objet présent dans le tiroir puis de détruire l'objet
    {
        Debug.Log(Go);
        if (ZoneManager.zoneActuelle == ourZone.eighties)
        {
            GameObject.Instantiate(Go, new Vector3(-1.732f, 1.02f, -0.9f), Go.transform.rotation);//On instancie au dessus du tiroir pour éviter des problèmes collision 
            //lorsque l'on tire le tiroir
        }
        else
        {

            GameObject.Instantiate(Go, transform.position, Go.transform.rotation); //Création d'un clone de l'objet
        }
        GameObject.Destroy(Go);//On détruit l'objet initial afin de le supprimer de DontDestroyOnLoad 
    }
    public void registerChildren(Transform tr)
    {
        // 2 - Cette fonction permet de créer le déplacement entre les temporalités du tiroir.
        if (ZoneManager.zoneActuelle == zoneTiroir)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                // 2 - On prend l'un des gameObject fils du tiroir
                GameObject child = transform.GetChild(i).gameObject;
                // 2 - On positionne le fils sur la position du tiroir
                child.transform.position = tr.position;
                // 2 - On redéfinit child en tant que fils du tiroir
                child.transform.SetParent(tr);          
            }
        }
    }
    private void OnTriggerEnter(Collider other)//Lorsqu'un objet entre dans le tiroir on l'ajoute à la liste des objets contenus dans le tiroir
    {
        if (other.tag != "Player" && !GoContained.Contains(other.gameObject))//On évite de mettre les mains dans le tiroir et les objets qui y sont déjà
        {
            GoContained.Add(other.gameObject);
            Debug.Log(other.name);
        }
    }

    private void OnTriggerExit(Collider other)//Lorsqu'un objet sort du tiroir, il est retiré de la liste s'il est dedans.
    {
        if (GoContained.Contains(other.gameObject))
        {
            GoContained.Remove(other.gameObject);

        }
    }
}
