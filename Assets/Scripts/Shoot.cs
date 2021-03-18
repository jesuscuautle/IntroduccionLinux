using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour{

    public Rigidbody balaPrefab;
    public Transform lanzador;
    public float velocidadB = 20;
    public float tiempoDisparo = 1;
    private float incioTiempoDisparo;

    void Update(){
        if (Input.GetMouseButton(0) && Time.time > incioTiempoDisparo){
            incioTiempoDisparo = Time.time + tiempoDisparo;
            Rigidbody balaPrefabI;
            balaPrefabI =  Instantiate(balaPrefab, lanzador.position, Quaternion.identity) as Rigidbody;
            balaPrefabI.AddForce(lanzador.forward*velocidadB);
        }
    }
}
