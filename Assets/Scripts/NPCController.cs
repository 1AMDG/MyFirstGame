using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    public float patrolTime = 10f, aggroRange = 10f;
    public Transform[] waypoints;

    private int index;
    public float speed, agentSpeed;
    private Transform player;

    //private Animator anim;
    private UnityEngine.AI.NavMeshAgent agent;

    void Awake () {
        //anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        if (agent != null) {
            agentSpeed = agent.speed;
        }
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        index = Random.Range (0, waypoints.Length);

        InvokeRepeating ("Tick", 0, 0.5f);

        if (waypoints.Length > 0) {
            InvokeRepeating ("Patrol", 0, patrolTime);
        }
    }

    void Patrol () {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }
    void Tick () {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed;
        if (player != null && Vector3.Distance (transform.position, player.position) < aggroRange) {
            agent.destination = player.position;
            agent.speed = agentSpeed + 0.5f;
            if (Vector3.Distance (waypoints[index].position, player.position) > 12) {
                agent.destination = waypoints[index].position;
                agent.speed = agentSpeed;
            }

        }

    }
}