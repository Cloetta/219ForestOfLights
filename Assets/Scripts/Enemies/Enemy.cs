using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Units/Enemy")]


public class Enemy : ScriptableObject
{
    //Storing all the stats of the enemy

    new public string name = "New Enemy";

    public int maxHP = 0;
    public int defence = 0;
    public int attackDamage = 0;
    public float attackSpeed = 0f;
    public float attackRange = 0f;
    public float movementSpeed = 0f;
    public float detectionRange = 0f;


    public bool isDefaultEnemy = false;

}