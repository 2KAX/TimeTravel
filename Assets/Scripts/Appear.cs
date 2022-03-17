using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    [SerializeField] Renderer[] meshes;
    [SerializeField] float duration;
    
    void Start()
    {
        if (meshes.Length == 0)
            meshes = GetComponentsInChildren<Renderer>();
    }

    public void Spawn()
    {
        StartCoroutine(Appearing());
    }

    IEnumerator Appearing()
    {
        for (float alpha = 1f; alpha >= 0; alpha -= duration / Time.deltaTime)
        {
            foreach (Renderer mesh in meshes)
            {
                Color color = mesh.material.color;
                color.a = alpha;
                mesh.material.color = color;
            }
            yield return null;
        }
    }
}
