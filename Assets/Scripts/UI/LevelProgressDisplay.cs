using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelProgressDisplay : MonoBehaviour
{
    //public int maxHealth;

    public TextMeshProUGUI textFireflies;
    
    public TextMeshProUGUI textLanterns;
    
    public TextMeshProUGUI textEnemies;
    


    public PlayerCombat player;
    public LevelManager level;
    public GameManager game;

    //public PlayerStats stats;


    private void Start()
    {
        player = FindObjectOfType<PlayerCombat>();
        level = FindObjectOfType<LevelManager>();
    }


    private void Update()
    {

        textFireflies.text = level.currentOpenJars.ToString() + " / " + level.totalJars.ToString(); 
        
        textLanterns.text = level.currentLanterns.ToString() + " / " + level.totalLanterns.ToString();
     
        textEnemies.text = game.enemiesDefeated.ToString() + " / " + game.enemiesInScene.Length.ToString();

        

    }
}
