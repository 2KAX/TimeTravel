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
        for (float alpha = 0; alpha < 1; alpha += duration / Time.deltaTime)
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
