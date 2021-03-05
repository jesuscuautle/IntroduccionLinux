using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir_enemigo : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            bool correEnemy = true;
            anim.SetBool("correr", correEnemy);
            nav.SetDestination(player.position);
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            bool correEnemy = false;
            anim.SetBool("correr", correEnemy);
        }

    }

}
