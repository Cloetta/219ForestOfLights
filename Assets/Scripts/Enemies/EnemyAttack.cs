using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //referencing to the detectingPlayer Script attached to the enemy
    [SerializeField]
    DetectingPlayer detecting;

    //On trigger enter function to detect the collision with the player in order to damage it.

    private void OnTriggerEnter (Collider other)
    {
       if (other.tag == "Player")
       {
            detecting.DamagePlayer();
            Debug.Log("Player is damaged!");
       }
    }


}
