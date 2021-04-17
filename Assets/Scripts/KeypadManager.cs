using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour{

    public GameObject puerta;
    public GameObject panelKeypad;
    public GameObject panelIndicaciones;
    public Input contraseñaUI;
    public float velocidadRotacion = 1f;
    public string contraseña;

    private bool abrir = false;
    private string contraseñaIngresada;
    private float angulo;
    private Vector3 direccion;

    private void Start(){
        angulo = puerta.transform.eulerAngles.y;
    }

    private void Update(){
        /*Aquí hay un error xd*/
        if(Mathf.Round(puerta.transform.eulerAngles.y) != angulo){
            puerta.transform.Rotate(direccion*velocidadRotacion);
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
            angulo = 90;
            direccion = Vector3.up;
        }
    }

}