using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpos : MonoBehaviour
{

    public GameObject casette;
    private GameObject currentTape;
    // Start is called before the first frame update
    void Start()
    {
        casette.transform.parent = transform.GetChild(0).transform;
        casette.transform.localPosition = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentTape = collision.gameObject;
        currentTape.transform.parent = transform.GetChild(0).transform;
        currentTape.transform.localPosition = Vector3.zero;
    }
}
