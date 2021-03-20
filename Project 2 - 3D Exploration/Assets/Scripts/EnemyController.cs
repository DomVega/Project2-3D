using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Decides whether the agent waits on each node
    [SerializeField]
    bool patrolWaiting;
    //The total time waited at node 
    [SerializeField]
    float totalWaitTime = 3f;
    //
    [SerializeField]
    float waitProbability = 0.5f;
    [SerializeField]
    float switchProbability = 0.2f;
    //List of all patrol nodes/points
    [SerializeField]
    List<Transform> patrolPoints;

    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool traveling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    public void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if(navMeshAgent == null)
        {
            Debug.Log("The NavMesh is not attached to " + gameObject.name);
        }
        else
        {
            if(patrolPoints != null && patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("There are not enough patrol points to patrol with");
            }
        }
    }
    
    //Checks if close to destination 
    public void Update()
    {
        //transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity,Vector3.up);
       if(traveling && navMeshAgent.remainingDistance <= 1.0f)
       {
           traveling = false;
           //if is going to wait then waits
           if(patrolWaiting)
           {
               waiting = true;
               waitTimer = 0f;
           }
           else
           {
               ChangePatrolPoint();
               SetDestination();
           }
       }
       //If we are waiting increment wait timer
       if(waiting)
       {
           waitTimer += Time.deltaTime;
           if (waitTimer >= totalWaitTime)
           {
               waiting = false;
               patrolWaiting = false;

               ChangePatrolPoint();
               SetDestination();
           }
       }
    }

    private void SetDestination()
    {
        if(patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            //transform.localRotation = Quaternion.LookRotation(targetVector);
            traveling = true;
        }
        
    }
    
    //Selects a new patrol point in the available list but also with a small probability of moving forwards or backwards
    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if(UnityEngine.Random.Range(0f, 1f) <= waitProbability)
        {
            patrolWaiting = true;
        }

        if(patrolForward)
        {
           currentPatrolIndex++;

           if(currentPatrolIndex >= patrolPoints.Count)
           {
               currentPatrolIndex = 0;
           }
        }
        else
        {
            currentPatrolIndex--; 

            if(currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoints.Count - 1;
            }
        }
    }
}
