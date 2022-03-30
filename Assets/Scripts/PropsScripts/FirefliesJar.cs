using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PULIRE

public class FirefliesJar : MonoBehaviour
{
    public bool inActionRange;
    public ParticleSystem lantern;
    public GameObject jarLid;

    public LevelManager sceneManager;
    public GameManager gameManager;

    public bool isUsed;

    [System.Obsolete]
    private void Awake()
    {
        lantern = GetComponentInChildren<ParticleSystem>();
        jarLid = GameObject.FindGameObjectWithTag("Lid");
        string used = PlayerPrefs.GetString("JarState" + gameObject.name);

        Debug.Log(PlayerPrefs.GetString("JarState" + gameObject.name));
        Debug.Log("used: " + used);


        if (used == "True")
        {
            isUsed = true;
            jarLid.SetActive(false);
            lantern.enableEmission = false;
        }
        else
        {
            isUsed = false;
            lantern.enableEmission = true;
            jarLid.SetActive(true);

        }
    }


    void Start()
    {
       
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneManager = GameObject.FindGameObjectWithTag("Scene").GetComponent<LevelManager>();
    }

    //Look on alternative sintax
    [System.Obsolete]
    void Update()
    {
        if (inActionRange == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && lantern.enableEmission == true)
            {
                Debug.Log("Free Fireflies");
                lantern.enableEmission = false;
                //lantern.startSpeed = 3f;
                Destroy(lantern, 10f);

                //qualche fade out effect? 

                //Add to the scene count 1 jar open
                sceneManager.currentOpenJars++;
                //Add to the game count 1 fireflies group freed
                gameManager.fireflies++;
                isUsed = true;

                //Deactivates lid of the jar to indicate player we already used this item
                jarLid.SetActive(false);

                //Maybe put it on save? 
                //PlayerPrefs.SetString("JarState" + gameObject.name, isUsed.ToString());

                //Debug.Log(PlayerPrefs.GetString("JarState" + gameObject.name));

            }
            else if (Input.GetKeyDown(KeyCode.Space) && lantern.enableEmission == false) //redundant or maybe i need it for debugging purposes?
            {
                Debug.Log("Those fireflies were already set free.");
            }

        }

        //SetToDefault(); //for debugging purposes

    }


    //private void SetToDefault()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        isUsed = false;
    //        PlayerPrefs.SetString("JarState" + gameObject.name, isUsed.ToString());
    //        Debug.Log("JarState" + gameObject.name + " is saved to " + isUsed.ToString());
    //    }
    //}

    public void SaveGameState() //needs to be accessed from the menu
    {

        PlayerPrefs.SetString("JarState" + gameObject.name, isUsed.ToString());
            Debug.Log("JarState" + gameObject.name + " is saved to " + isUsed.ToString());




        //save.fireflies = fireflies;
        //save.lanterns = lanterns;
        //save.milestones = milestones;
        //save.challengeRating = challengeRating;
        //save.enemiesDefeated = enemiesDefeated;
        //if in main menu or other scenes, it shouldn't allow you to save, unless i completely remove the button from the menu in the introduction scene

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inActionRange = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inActionRange = false;
        }
    }



}
