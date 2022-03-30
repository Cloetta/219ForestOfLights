using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private FloatyMovement playerScript;
    private MouseController mouseScript;

    public GameObject inGameMenu;

    public bool menuOn = false;


    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FloatyMovement>();
        mouseScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseController>();
    }


    private void Update()
    {
        //Call the player script so we can disable it temporarily while the inventory is open
        

        //Esc to open the menu in game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuOn == false)
            {
                inGameMenu.SetActive(true);
                playerScript.enabled = false;
                mouseScript.enabled = false;
                Time.timeScale = 0f; //Game is paused while the inventory is open
                menuOn = true;
                Cursor.lockState = CursorLockMode.None;
                //FindObjectOfType<AudioSystem>().Play("MenuClick"); //Feedbackfor opening the menu
            }
            else
            {
                inGameMenu.SetActive(false);
                playerScript.enabled = true;
                mouseScript.enabled = true;
                Time.timeScale = 1f;
                menuOn = false;
                //FindObjectOfType<AudioSystem>().Play("Remove"); //Feedback for closing the menu
            }

        }

    }

    //Resume game closing the menu and putting back the normal time flow
    public void ResumeGame()
    {
        menuOn = false;
        Time.timeScale = 1f;
        playerScript.enabled = true;
        mouseScript.enabled = true;

        //Makes the cursor disappear from the screen when in playmode and lock it at the center of the screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadLevelsMenu()
    {
        SceneManager.LoadScene("SelectLevelMenu");
    }


    //Exit game
    public void ExitGame()
    {
       Application.Quit();
       
    }




}
