using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planterGraine : MonoBehaviour
{
    //Script associé au pot pour planter la graine

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Graine")
        {
            other.gameObject.transform.position = this.transform.position; // On met la graine dans le pot
            Destroy(other.gameObject.GetComponent<Rigidbody>()); //Pour ne plus pouvoir prendre la graine
        }
    }
}
