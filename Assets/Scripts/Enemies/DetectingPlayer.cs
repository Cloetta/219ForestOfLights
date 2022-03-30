using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPlayer : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Enemy enemyStats;
    [SerializeField]
    private Patroling patrol; //nope for now

    [SerializeField]
    GameObject player;
    PlayerCombat playerComb;
    [SerializeField]
    GameManager gameManager;


    private float distance;
    private float nextAttack;
    public float angle = 160f; //needs to be public for the editor script

    private int currentHp;

    //make them private after debugging!
    public float radius;
    public bool inRange = false;
    public bool canAttack;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private void Start()
    {
        radius = enemyStats.detectionRange;
        playerComb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        currentHp = enemyStats.maxHP;
    }

    public Vector3 FromVector
    {
        get
        {
            float leftAngle = -angle / 2;
            leftAngle += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(leftAngle * Mathf.Deg2Rad), 0, Mathf.Cos(leftAngle * Mathf.Deg2Rad));
        }
    }



    void Update()
    {

        if (currentHp <= 0)
        {
            animator.SetBool("isDead", true);

            Destroy(gameObject, 7f);
        }

        /////CLEAN ///////

        //normalised:
        Vector3 directionVector = (transform.position - player.transform.position).normalized;

        //Vector3 directionVector = transform.position - player.transform.position;
        // note: the following only looks at x-z axis, i.e. the 20 distance ignoring the height
        // distance = Mathf.Sqrt(Mathf.Pow(directionVector.x, 2) ] Mathf.Pow(directionVector.z, 2));

        distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log("Distance: " + distance);

        float dotProduct = Vector3.Dot(directionVector, transform.forward);

        if (dotProduct < -0.5f && distance <= 10f && distance >= -10f)
        {
            // Debug.Log(dotProduct + " : in field of view. Distance - " + distance);
            inRange = true;
            //Debug.Log("Player has been spotted!");

            

            //enemy moves towards player

            if (distance <= enemyStats.attackRange && Time.time >= nextAttack)
            {

                Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, enemyStats.attackRange, enemyLayers);

                //Apply damage to enemies
                foreach (Collider player in hitPlayer)
                {
                    //Debug line
                    //Debug.Log("We hit " + player.name);

                   
                    DamagePlayer();
                }

                canAttack = true;
                animator.SetTrigger("isAttacking");
                //attack damage and stuffffffff
                nextAttack = Time.time + 1f / enemyStats.attackSpeed;
               
            }
            else
            {
                animator.SetTrigger("isWaiting");
            }

        }
        else
        {
            // Debug.Log(dotProduct + " : out of sight. Distance - " + distance);
            inRange = false;
            canAttack = false;
           
        }
    }

    void TakeDamage(int damage)
    {
        if (currentHp < 0f)
        {
            return;
        }

        currentHp -= damage;
    }

    public void DamagePlayer()
    {
        if (playerComb.currentHealth < 0f)
        {
            return;
        }

        playerComb.currentHealth -= enemyStats.attackDamage;

        Debug.Log("Player is taking damage: " + enemyStats.attackDamage);
        Debug.Log("Player current health " + playerComb.currentHealth);

    }

    private void OnDestroy()
    {
        gameManager.enemiesDefeated++;
    }

    //Draw a circle representing the attack range of the enemy
    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, enemyStats.attackRange);
    }




}
