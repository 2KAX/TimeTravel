using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planterGraine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Graine")
        {
            other.gameObject.transform.SetParent(this.transform);
            other.gameObject.transform.localPosition = Vector3.zero;
            Destroy(other.gameObject.GetComponent<Rigidbody>());
        }
    }
}
