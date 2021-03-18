using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ourZone { eighties, Western, fifties ,green }

public class ZoneManager : MonoBehaviour
{
    public static ourZone zoneActuelle = ourZone.eighties;


    private static bool used80 = false;
    private static bool usedWest = false;
    private static bool usedfutur = false;
    static bool existsInstance = false;

    public bool Used80
    {
        get
        {
            return used80;
        }
        set
        {
            used80 = value;
        }
    }
    public bool Usedwest
    {
        get
        {
            return usedWest;
        }
        set
        {
            usedWest = value;
        }
    }
    public bool Usedfutur {
        get { return usedfutur; }
        set { usedfutur = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (existsInstance)
        {
            Destroy(gameObject);
            return;
        }
        existsInstance = true;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

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
