using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ourZone { eighties, Western, fifties ,green }

public class New_ZoneManager : MonoBehaviour
{
    public static ourZone zoneActuelle = ourZone.eighties;


    private static bool used80 = false;
    private static bool usedWest = false;
    private static bool usedfutur = false;

    public bool Used80
    {
        get
        {
            return used80;
        }
    }
    public bool Usedwest
    {
        get
        {
            return usedWest;
        }
    }
    public bool Usedfutur {
        get { return usedfutur; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);


    }

    void Start()
    {
        //3. on commence le jeux dans la scene 80s 
        // SceneManager.LoadScene("80s");
       // Instantiate(Instantiate((GameObject)Resources.Load("Prefabs/K7rock1989queen_2050"), new Vector3(2f, 2f, 2f), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void GoToA()
    {
        SceneManager.LoadScene("80s");
        used80 = true;
        zoneActuelle = ourZone.eighties;
        Debug.Log("Going to 80s !");
    }

    public void GoToB()
    {
        SceneManager.LoadScene("2050");
        usedfutur = true;
        zoneActuelle = ourZone.fifties;
        Debug.Log("Going to 2050s !");
    }

    public void GoToC()
    {
        SceneManager.LoadScene("Western");
        usedWest = true;
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
