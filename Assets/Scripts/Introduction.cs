using System.Collections;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    [SerializeField] float startDelay;
    [SerializeField] messagemanager message;
    [SerializeField] Renderer[] meshes;
    [SerializeField] [Range(0, 10)] float dissolveDuration = 1;

    void Awake()
    {
        if (meshes.Length == 0)
            meshes = GetComponentsInChildren<Renderer>();
        if (!message)
            message = FindObjectOfType<messagemanager>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(startDelay);
        yield return Dissolve(1, 0, dissolveDuration);
        message.Display();
        while (!message.IsEndMessage)
            yield return null;
        yield return Dissolve(0, 1, dissolveDuration);
    }

    IEnumerator Dissolve(float begin, float end, float duration)
    {
        for (float t = 0; t < 1;)
        {
            t += Time.deltaTime / duration;
            foreach (Renderer mesh in meshes)
                mesh.material.SetFloat("Dissolve", begin + t * (end - begin));
            yield return null;
        }
    }
}
