using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TO DO: scene transition: animator and transitionTime

    //Static instance of GameManager which allows it to be accessed by any other script
    public static GameManager instance = null;

    bool isGameOver = false;

    public int fireflies;
    public int lanterns;
    public int milestones;
    public int challengeRating;
    public int enemiesDefeated;

    public string nextScene;
    public bool isLevelComplete;

    public GameObject[] lanternsInScene;
    public GameObject[] enemiesInScene;

    public GameManagerSave save; //private? 

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //Sets "this" to not be destroyed when reloading scene
        DontDestroyOnLoad(this.gameObject);

        LoadGameState();
    }

    private void Start()
    {
        fireflies = PlayerStats.collectedFireflies;
        lanterns = PlayerStats.lanterns;
        milestones = PlayerStats.milestoneLevel;
        challengeRating = PlayerStats.challengeRating;

        lanternsInScene = GameObject.FindGameObjectsWithTag("Lantern");
        enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }

        if(PlayerStats.currentHP <= 0)
        {
            isGameOver = true;
        }


    }

    public void GameOver()
    {
        SceneManager.LoadScene("SelectLevelMenu");
    }

    public void LoadGameState() //needs to be accessed from the menu
    {
        fireflies = save.fireflies;
        lanterns = save.lanterns;
        milestones = save.milestones;
        challengeRating = save.challengeRating;
        enemiesDefeated = save.enemiesDefeated;
    }

    public void SaveGameState() //needs to be accessed from the menu
    {

        save.fireflies = fireflies;
        save.lanterns = lanterns;
        save.milestones = milestones;
        save.challengeRating = challengeRating;
        save.enemiesDefeated = enemiesDefeated;
        //if in main menu or other scenes, it shouldn't allow you to save, unless i completely remove the button from the menu in the introduction scene

    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();

        save.fireflies = 0;
        save.lanterns = 0;
        save.milestones = 0;
        save.challengeRating = 0;
        save.enemiesDefeated = 0;

        Debug.Log("New Game has started.");




    }

}
