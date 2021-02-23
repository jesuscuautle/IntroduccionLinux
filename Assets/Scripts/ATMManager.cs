using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ATMManager : MonoBehaviour{

    public ATM atm;
    Queue<string> textos;
    public GameObject panelATM;
    public GameObject panelIndicaciones;
    public TextMeshProUGUI mostrarTexto;
    string textoActual;
    public float velTexto;

    private void Start() {
        textos = new Queue<string>();
    }

    void StartType(){
        textos.Clear();
        foreach (string texto in atm.textoATM){
            textos.Enqueue(texto);
        }
        mostarSiguienteTexto();
    }

    void mostarSiguienteTexto(){
        if(textos.Count <= 0){
            mostrarTexto.text = textoActual;
            return;
        }
        textoActual = textos.Dequeue();
        mostrarTexto.text = textoActual;
        StopAllCoroutines();
        StartCoroutine(escribeTexto(textoActual));
    }

    IEnumerator escribeTexto(string texto){
        mostrarTexto.text = "";
        foreach (char letra in texto.ToCharArray()){
            mostrarTexto.text += letra;
            yield return new WaitForSeconds(velTexto);
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
                panelATM.SetActive(true);
                StartType();
            }
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Player")){
            panelIndicaciones.SetActive(false);
            panelATM.SetActive(false);
        }
    }

    

    public void SalirButton(){
        panelATM.SetActive(false);
    }

}