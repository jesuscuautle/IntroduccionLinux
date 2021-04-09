using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour{

    public GameObject puerta;
    public GameObject panelKeypad;
    public GameObject panelIndicaciones;
    public Input contraseñaUI;
    public int velocidadRotacion = 100;

    private bool abrir = false;
    private string contraseña;
    private string contraseñaIngresada;

    private void Start(){
        contraseña = "1"; //DEFINIR CONTRASEÑA
    }

    private void Update(){
        /*Aquí hay un error xd*/
        if(abrir){
            puerta.transform.RotateAround(puerta.transform.position, new Vector3(0, 1, 0), velocidadRotacion*Time.deltaTime);
            if(puerta.transform.rotation.y == 110){
                abrir = false;
            }
            
        }
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Player")){
            panelIndicaciones.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider collider){
        if(collider.CompareTag("Player")){
            if(Input.GetKeyDown("e")){
                panelIndicaciones.SetActive(false);
                panelKeypad.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Player")){
            panelIndicaciones.SetActive(false);
            panelKeypad.SetActive(false);
        }
    }

    public void ExitButton(){
        panelKeypad.SetActive(false);
    }

    public void checkPassword(string input){
        if(input == contraseña){
            panelKeypad.SetActive(false);
            abrir = true;
        }
    }

}