﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer_constraint : MonoBehaviour {

    public Transform Limit_transform;
    private float limit_position;

	// Use this for initialization
	void Start () {
        limit_position = Limit_transform.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x - limit_position < 0)
            transform.position = new Vector3(limit_position , transform.position.y, transform.position.z);
	}
}
