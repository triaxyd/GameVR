using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveNPC : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform player;

    // Waypoint behind the player
    [SerializeField]
    private Transform playerBack; 

    // Waypoint in front of the player
    [SerializeField]
    private Transform playerFront;

    [SerializeField]
    private float rotationSpeed = 5f;

    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Calculate the squared distances to avoid the overhead of square root
        float distanceToBack = (playerBack.position - transform.position).sqrMagnitude;
        float distanceToFront = (playerFront.position - transform.position).sqrMagnitude;

        // Move towards the closer waypoint
        if (distanceToBack * 0.5 < distanceToFront)
        {
            agent.SetDestination(playerBack.position);
        }
        else
        {
            agent.SetDestination(playerFront.position);
        }

        Vector3 direction = (player.position - transform.position).normalized;
        if (direction != Vector3.zero) // Prevent NaN errors if direction is zero
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
