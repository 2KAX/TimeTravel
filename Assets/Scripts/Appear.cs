using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    [SerializeField] Renderer[] meshes;
    [SerializeField] [Range(0, 10)] float duration;
    
    void Start()
    {
        if (meshes.Length == 0)
            meshes = GetComponentsInChildren<Renderer>();
    }

    public void StartAppearing()
    {
        StartCoroutine(Appearing());
    }

    IEnumerator Appearing()
    {
        for (float alpha = 0; alpha < 1; alpha += Time.deltaTime / duration)
        {
            foreach (Renderer mesh in meshes)
                mesh.material.SetFloat("Threshold", alpha);
            yield return null;
        }
    }
}
