using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroling : MonoBehaviour
{
    [SerializeField]
    //Transform destination;
    NavMeshAgent navMeshAgent;
    GameObject currentWaypoint;
    GameObject previousWaypoint;
    GameObject[] allWaypoints;
    [SerializeField]
    Animator animator;
    [SerializeField]
    DetectingPlayer detecting;
    [SerializeField]
    GameObject player;

    bool isTravelling;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        allWaypoints = GameObject.FindGameObjectsWithTag("PatrolingPoint");
        currentWaypoint = GetRandomWaypoint();

        player = GameObject.FindGameObjectWithTag("Player");


        if(navMeshAgent == null)
        {
            Debug.LogError("The NavMeshAgent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }

    }

    
    void Update()
    {
        if(isTravelling && navMeshAgent.remainingDistance <= 1f)
        {
            isTravelling = false;
            
            SetDestination();

        }
        else if (detecting.inRange)
        {
            targetPlayer();

            if (detecting.canAttack)
            {
                Vector3 targetVector = Vector3.zero;
                isTravelling = false;
                
                navMeshAgent.SetDestination(targetVector);
            }



        }
        
        
    }

    void SetDestination()
    {
        previousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        Vector3 targetVector = currentWaypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);
        isTravelling = true;
        //animator.SetTrigger("isMoving");
    }

    public GameObject GetRandomWaypoint()
    {
        if (allWaypoints.Length == 0)
        {
            return null;
        }
        else
        {
            int index = Random.Range(0, allWaypoints.Length);
            return allWaypoints[index];
        }
    }

    void targetPlayer()
    {
        Vector3 targetVector = player.transform.position;
        navMeshAgent.SetDestination(targetVector);
        //animator.SetTrigger("isMoving");
        isTravelling = true;
    }


}
