using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour{

    public int vidaInicial = 5;
    public int vidaActual;
    //public AudioClip audioMuerte;

    private Animator animacionMuerte;
    private PlayerMovement pm;
    private bool isDead;
    
    void Awake(){

        animacionMuerte = GetComponent<Animator>();
        //pm = GetComponent<PlayerMovement>();
        vidaActual = vidaInicial;

    }

    void Update(){
        
    }

    public void RecibirDanio(int danio){

        vidaActual -= danio;
        if(vidaActual <= 0 && !isDead){
            isDead = true;
            animacionMuerte.SetTrigger("muere");
            pm.setCanMove(false);
        }

    }

}
