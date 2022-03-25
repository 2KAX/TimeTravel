using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTiroir80s : MonoBehaviour
{
    [SerializeField]
    private tiroir drawer; // Le script du modèle du tiroir
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - drawer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = drawer.transform.position + offset;
    }

    // Méthodes de tiroir.cs déplacées dans ce script et adaptées
    private void OnTriggerEnter(Collider other)//Lorsqu'un objet entre dans le tiroir on l'ajoute à la liste des objets contenus dans le tiroir
    {
        if (other.tag != "Player" && !tiroir.GoContained.Contains(other.gameObject))//On évite de mettre les mains dans le tiroir et les objets qui y sont déjà
        {
            tiroir.GoContained.Add(other.gameObject);
            Debug.Log(other.name);
        }
    }
    private void OnTriggerExit(Collider other)//Lorsqu'un objet sort du tiroir, il est retiré de la liste s'il est dedans.
    {
        if (tiroir.GoContained.Contains(other.gameObject))
        {
            tiroir.GoContained.Remove(other.gameObject);

        }
    }
}
