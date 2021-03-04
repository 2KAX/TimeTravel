using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ourZone { eighties, Western, fifties ,green }

public class New_ZoneManager : MonoBehaviour
{
    public static ourZone zoneActuelle = ourZone.eighties;

    // Start is called before the first frame update
    void Start()
    {
        //3. on commence le jeux dans la scene 80s 
        SceneManager.LoadScene("80s");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToA()
    {
        SceneManager.LoadScene("80s");
        Debug.Log("Going to 80s !");
    }

    public void GoToB()
    {
        SceneManager.LoadScene("2050");
        Debug.Log("Going to 2050s !");
    }

    public void GoToC()
    {
        SceneManager.LoadScene("Western");
        Debug.Log("Going to Western !");
    }

    public void GoToFin()
    {
        SceneManager.LoadScene("Green2050");
        Debug.Log("Going to Gagne !");
    }
}
