using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRenderer : MonoBehaviour
{
    float speed = 1f;

    public PlayerCombat player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    void Update()
    {


        Vector3 Position = transform.position;

        //Vector3 Target = ;

        //Vector3 attack = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);

        
    }

    
    
}
