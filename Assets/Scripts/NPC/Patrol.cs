using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    private int currentWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("Reached destination");
            GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint() 
    {
        // Set the destination to the current waypoint
        agent.SetDestination(waypoints[currentWaypoint].position);

        // Go to next waypoint
        currentWaypoint++;

        // Reset the waypoints array when traversed every waypoint
        currentWaypoint %= waypoints.Length;

        Debug.Log($"Current waypoint {currentWaypoint}");
    }
}
