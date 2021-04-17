using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour{
    
    public Text contador;
    public GameObject panelContador;
    public GameObject panelGameOver;
    public float tiempoInicial;

    private float tiempoIncremento;

    void Start(){
        contador.text = ""+tiempoInicial;
    }

    void Update(){
        tiempoInicial -= Time.deltaTime;
        contador.text = ""+tiempoInicial.ToString("f0");
        if(tiempoInicial <= 0){
            GameOver();
        }
    }

    private void GameOver(){
        contador.text = "0";
        panelGameOver.SetActive(true);
        panelContador.SetActive(false);
    }

}
