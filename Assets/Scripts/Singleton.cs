using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    static bool existsInstance = false;

    private void Awake()
    {
		if (existsInstance)
		{
			Destroy(gameObject);
			return;
		}
		existsInstance = true;
	}

}
