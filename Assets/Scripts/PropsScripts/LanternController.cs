using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PULIRE

public class LanternController : MonoBehaviour
{

    public bool inActionRange;
    public ParticleSystem lantern;
    public LevelManager sceneManager;
    public GameManager gameManager;
    public bool isActive; //need or not?

    [System.Obsolete]
    private void Awake()
    {
        lantern = GetComponentInChildren<ParticleSystem>();

        string active = PlayerPrefs.GetString("LanternState" + gameObject.name);

        Debug.Log(PlayerPrefs.GetString("LanternState" + gameObject.name));
        Debug.Log("active: " + active);


        if (active == "True")
        {
            isActive = true;
            lantern.enableEmission = true;
        }
        else
        {
            isActive = false;
            lantern.enableEmission = false;
        }


        //isActive.ToString() = PlayerPrefs.GetString(isActive.ToString());
    }
    

    void Start()
    {
        //lantern = GetComponentInChildren<ParticleSystem>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        sceneManager = GameObject.FindGameObjectWithTag("Scene").GetComponent<LevelManager>();
        //isActive = false;

        Debug.Log(PlayerPrefs.GetString("LanternState" + gameObject.name));

    }

    //Look on alternative sintax 
    [System.Obsolete]
    void Update()
    {
        if(inActionRange == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && lantern.enableEmission == false)
            {
                Debug.Log("Activate Lantern");
                lantern.enableEmission = true;
                sceneManager.currentLanterns++;
                gameManager.lanterns++;
                isActive = true;

            }
            else if (Input.GetKeyDown(KeyCode.Space) && lantern.enableEmission == true) //redundant or maybe i need it for debugging purposes?
            {
                Debug.Log("This lantern was already activated.");
                
            }                  
        }

        //SetToDefault(); //for debugging purposes
                   
    }




    public void SaveGameState() //needs to be accessed from the menu
    {

        //Maybe put it on save? 
        PlayerPrefs.SetString("LanternState" + gameObject.name, isActive.ToString());
        Debug.Log(PlayerPrefs.GetString("LanternState" + gameObject.name));

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




    //private void SetToDefault()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        isActive = false;
    //        //PlayerPrefs.SetString("LanternState" + gameObject.name, isActive.ToString());
    //        //Debug.Log("LanternState" + gameObject.name + " is saved to " + isActive.ToString());


    //        PlayerPrefs.DeleteAll();
    //    }
            
    //}
}
