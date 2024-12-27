using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] private Transform[] waypoints;
    private int currentWaypoint;
    private bool isWaiting = false;
    [SerializeField] private GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isWaiting)
        {
            StartCoroutine(WaitAndGoToNextWaypoint());
        }
    }

    // Coroutine to wait for a random time before going to the next waypoint
    IEnumerator WaitAndGoToNextWaypoint()
    {
        // Set flag to indicate that we are waiting
        isWaiting = true;
        // Wait for a random time
        float waitTime = Random.Range(1f, 2f);
        // Go into house and then go again
        if (currentWaypoint == 2)  
        {
            waitTime = Random.Range(5f, 10f); 
        }
        yield return new WaitForSeconds(waitTime);
        GoToNextWaypoint(); // Move to the next waypoint after waiting
        isWaiting = false; // Reset flag to allow the next waiting cycle
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypoint].position;

        // Move to the next waypoint (wrap around if at the end of the array)
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}
