using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentAnimation : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude > 0) animator.SetBool("Walking", true);
        else animator.SetBool("Walking", false);
    }
}
