using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameManager", menuName = "Save/GameManager")]
public class GameManagerSave : ScriptableObject
{
    new public string name = "New Game Manager";

    bool isGameOver = false;

    public int fireflies = 0;
    public int lanterns = 0;
    public int milestones = 0;
    public int challengeRating = 0;
    public int enemiesDefeated = 0;

    public bool isLevelComplete;



}
