using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{

    public InGameUI hpBar;
    public InGameUI manaBar;

    public static PlayerCombat instance;

    public GameObject attackOrigin; 
    public GameObject particle; 


    public int maxHealth;
    public int currentHealth;
    public float attackRange;
    public float attackSpeed;
    public float nextAttack;

    public int maxMana;
    public int currentMana;
    private float manaRegenTime;

    private void Awake()
    {
        ////Create a non-destroyable instance of the player so that we don't lose data between scenes
        //if (instance != null)
        //{
        //    Destroy(this.gameObject);

        //    return;
        //}

        //instance = this;

        ////Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        currentHealth = PlayerStats.currentHP;
        currentMana = PlayerStats.currentMP;

        attackRange = PlayerStats.attackRange;
        attackSpeed = PlayerStats.attackSpeed;

        maxHealth = currentHealth;
        maxMana = currentMana;

        hpBar.SetMaxHealth(maxHealth);
        hpBar.SetHealth(currentHealth);

        manaBar.SetMaxMp(maxMana);
        manaBar.SetMp(currentMana);

        //ADD ALSO ALL THE OTHER STATS
        
        Debug.Log("Start HP: " + maxHealth);
        Debug.Log("Start MP: " + maxMana);

        attackOrigin = GameObject.FindGameObjectWithTag("CastOrigin");

    }

    // Update is called once per frame
    void Update()
    {
        //Condition to trigger mana regeneration, 1 point per second
        if (maxMana > currentMana)
        {
            if (Time.time >= manaRegenTime)
            {
                currentMana++;
                manaRegenTime = Time.time + 1f;
            }
        }

        //Check the current health/mana value is not going over the estabilished max
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }


        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        //Updating the player hp and sugar(mana) bars
        manaBar.SetMp(currentMana);
        hpBar.SetHealth(currentHealth);

        //waiting for the next attack time based on the player attack speed
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= nextAttack)
            {
                BasicAttack();
                nextAttack = Time.time + 1f / attackSpeed;
            }
       
        }


    }


    void BasicAttack()
    {
        
        

        Vector3 origin = attackOrigin.transform.position;
        Vector3 direction = attackOrigin.transform.TransformDirection(Vector3.forward);
        RaycastHit hitObject;
        Ray ray = new Ray(attackOrigin.transform.position, direction);

        int damage = 10;

        GameObject baseAttack = Instantiate(particle, attackOrigin.transform.position, transform.rotation) as GameObject; 
        //rigBody = baseAttack.GetComponent<Rigidbody>();

        //float speed = 4f;
       // Vector3 target = new Vector3(0f, 0f, attackRange);

        //Vector3 attack = Vector3.MoveTowards(origin, target, speed * Time.deltaTime);
        //baseAttack.transform.position = attack;

        //rigBody.AddRelativeForce(direction * speed);

        Destroy(baseAttack, 1f);

        if (Physics.Raycast(ray, out hitObject, attackRange))
        {

            //attack = baseAttack.gameObject.GetComponent<LineRenderer>();

            //attack.SetPositions(new Vector3[]{attackOrigin.transform.position, hitObject.point});
            //Vector3 target = hitObject.point;

            

            //baseAttack.Move(moveDirection * Time.deltaTime);

            //Vector3 attack = Vector3.MoveTowards(origin, target , speed * Time.deltaTime);
            //baseAttack.transform.position = attack;
            //Destroy(baseAttack, 1.5f);

            Debug.DrawLine(origin, hitObject.point, Color.magenta);

            hitObject.collider.SendMessageUpwards("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

            //endPosition = raycastHit.point;

            Debug.Log("EnemyDamaged: " + damage);

            Debug.Log("position: " + hitObject.point.ToString());

            Debug.Log("Test: " + hitObject.distance.ToString());
        }
    }

   
   

}
