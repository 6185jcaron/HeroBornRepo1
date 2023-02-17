using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform patrolRoute;
    public List<Transform> Locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent <NavMeshAgent>();
        MoveToNextPatrolLocation();
    }
    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            Locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        agent.destination = Locations[locationIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //1
    void OnTriggerEnter(Collider other)
    {
        //2
        if (other.name == "Player")
        {
            Debug.Log("Player detected - Attack!");
        }
    }
    //3
    void OnTriggerExit(Collider other)
    {
        //4
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
    
}
