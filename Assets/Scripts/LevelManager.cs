using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour
{
    public SceneStats sceneStats; //scriptable object with data goes here. this will allow us to save the level state ??? Try this
    public GameManager gameManager;
    public GameObject win;

    //All lanterns need to be turned on in the scene.
    public int totalLanterns = 0;
    public int currentLanterns = 0;

    public int totalJars = 0;
    public int minJars = 0;
    public int currentOpenJars = 0;

    public bool isWin;
    public bool isComplete;



    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        totalLanterns = sceneStats.totalLanterns;
        currentLanterns = sceneStats.currentLanterns;

        totalJars = sceneStats.totalJars;
        minJars = sceneStats.minJars;
        currentOpenJars = sceneStats.currentOpenJars;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLanterns == totalLanterns && minJars <= currentOpenJars)
        {
            isWin = true;
            win.SetActive(true);
            Time.timeScale = 0f;
            //functions that refer to another separate script which will determine if the next level is unlockable or not. (maybe i can play with playerpref again to access the variable?)
        }
        else
        {
            isWin = false;
        }

        if (currentLanterns == totalLanterns && totalJars == currentOpenJars) // do we need this? maybe not
        {
            isComplete = true;
        }
        else
        {
            isComplete = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }



    }

    public void SaveGameState() //needs to be accessed from the menu
    {

        sceneStats.currentLanterns = currentLanterns;
        sceneStats.currentOpenJars = currentOpenJars;

    }

    public void LoadGameState() //needs to be accessed from the menu
    {
        currentLanterns = sceneStats.currentLanterns;
        currentOpenJars = sceneStats.currentOpenJars;
    }

    public void NewGame()
    {
        sceneStats.currentLanterns = 0;
        sceneStats.currentOpenJars = 0;
        currentLanterns = 0;
        currentOpenJars = 0;
    }






}
