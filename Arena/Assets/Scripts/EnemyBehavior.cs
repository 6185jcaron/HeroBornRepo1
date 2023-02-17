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
    public Transform player;
    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }

    }
    void Start()
    {
        InitializePatrolRoute();
        agent = GetComponent <NavMeshAgent>();
        player = GameObject.Find("Player").transform;
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
        if (Locations.Count == 0)
            return;
        locationIndex = (locationIndex + 1) % Locations.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }


    //1
    void OnTriggerEnter(Collider other)
    {
        //2
        if (other.name == "Player")
        {
            agent.destination = player.position;
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
