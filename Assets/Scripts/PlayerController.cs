using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //private Animator anim;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake()
    {
        //anim = GetComponent<Animator>()
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
