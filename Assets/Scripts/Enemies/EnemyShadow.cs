using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadow : MonoBehaviour
{
    public float lifePoints;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Enemy enemyStats; //nope
    [SerializeField]
    private DetectingPlayer detector;
    [SerializeField]
    private Patroling patrol; //nope for now
    [SerializeField]
    GameManager gameManager;

    private void Start()
    {
        lifePoints = enemyStats.maxHP;
    }

    private void Update()
    {
        if (lifePoints <= 0)
        {
            

            Destroy(gameObject, 7f);
        }
    }

    void ApplyDamage(float damage)
    {
        if (lifePoints <= 0f)
        {
            animator.SetTrigger("isDead");
            return;
        }

        lifePoints -= damage;
    }

   
}
