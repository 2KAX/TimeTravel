using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ourZone { eighties, Western, fifties ,green }

public class New_ZoneManager : MonoBehaviour
{
    public static ourZone zoneActuelle = ourZone.eighties;
    public GameObject[] tapes;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(tapes[0]);
        DontDestroyOnLoad(tapes[1]);
        DontDestroyOnLoad(tapes[2]);
    }

    void Start()
    {
        //3. on commence le jeux dans la scene 80s 
       // SceneManager.LoadScene("80s");
    
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void GoToA()
    {
        SceneManager.LoadScene("80s");
        zoneActuelle = ourZone.eighties;
        Debug.Log("Going to 80s !");
    }

    public void GoToB()
    {
        SceneManager.LoadScene("2050");
        zoneActuelle = ourZone.fifties;
        Debug.Log("Going to 2050s !");
    }

    public void GoToC()
    {
        SceneManager.LoadScene("Western");
        zoneActuelle = ourZone.Western;
        Debug.Log("Going to Western !");
    }

    public void GoToFin()
    {
        SceneManager.LoadScene("Green2050");
        zoneActuelle = ourZone.green;
        Debug.Log("Going to Gagne !");
    }
}
