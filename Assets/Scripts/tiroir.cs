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
    public static List<GameObject> GoContained = new List<GameObject>();
    public ourZone zoneTiroir;
    public List<GameObject> GoCont
    {
        get{ return GoContained; }
    }
    public void Awake()
    {
        foreach(GameObject Go in GoContained)
        {
            DestroyandCreate(Go);
        }
        GoContained.Clear();

    }
    public void DestroyandCreate(GameObject Go)
    {
        Debug.Log(Go);
        if (ZoneManager.zoneActuelle == ourZone.eighties)
        {
            GameObject.Instantiate(Go, new Vector3(-1.732f,1.02f,-0.9f), Go.transform.rotation);
        }
        else { GameObject.Instantiate(Go, transform.position, Go.transform.rotation); }
        GameObject.Destroy(Go);
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

    // Adds DontDestroyOnLoad for all objects inside the Drawer
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && !GoContained.Contains(other.gameObject))
        {
            //other.gameObject.transform.parent = null;
           // DontDestroyOnLoad(other.gameObject);
            GoContained.Add(other.gameObject);
            Debug.Log(other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (GoContained.Contains(other.gameObject))
        //{
         //   GoContained.Remove(other.gameObject);

      //  }
    }
}
