using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    //public int maxHealth;

    public TextMeshProUGUI textMaxHealth;
    public TextMeshProUGUI textMaxMP;
    public TextMeshProUGUI textAttkRange;
    public TextMeshProUGUI textAttkSpeed;
    public TextMeshProUGUI textFireflies;
    public TextMeshProUGUI textLanterns;
    public TextMeshProUGUI textMilestones;
    public TextMeshProUGUI textChallengeRating;

    public PlayerCombat player;
    public GameManager game;

    //public PlayerStats stats;


    private void Start()
    {
        player = FindObjectOfType<PlayerCombat>();
        game = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        textMaxHealth.text = player.maxHealth.ToString();
        textMaxMP.text = player.maxMana.ToString();
        textAttkRange.text = player.attackRange.ToString();
        textAttkSpeed.text = player.attackSpeed.ToString();
        textFireflies.text = game.fireflies.ToString();
        textLanterns.text = game.lanterns.ToString();
        textMilestones.text = game.milestones.ToString();
        textChallengeRating.text = game.challengeRating.ToString();


        //debugging - to delete
        if (Input.GetKeyDown(KeyCode.I))
        {
            player.maxHealth--;

            game.lanterns++;

            //OK
        }


    }




}
