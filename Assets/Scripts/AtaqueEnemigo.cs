using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour{

    public float velAtaque = 1.5f;
    public int danio = 1;

    private Animator animacionEnemigo;
    private GameObject player;
    private Damage damage;
    private bool inRange;
    private float timer;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        damage = player.GetComponent<Damage>();
        animacionEnemigo = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider){

        if (collider.CompareTag("Player"))
        {
            inRange = true;
        }

    }

    void OnTriggerExit(Collider collider){

        if (collider.CompareTag("Player"))
        {
            inRange = false;
        }

    }

    void Update(){

        timer += Time.deltaTime;

        if(timer >= velAtaque && inRange){
            timer = 0f;
            if(damage.vidaActual > 0){
                damage.RecibirDanio(danio);
            }
        }
        if(damage.vidaActual <= 0){
            animacionEnemigo.SetTrigger("PlayerD");
        }

    }

}
