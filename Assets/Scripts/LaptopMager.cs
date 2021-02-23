using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaptopMager : MonoBehaviour{
    
    public Laptop laptop;
    Queue<string> textos;
    public GameObject panelBash;
    public GameObject panelIndicaciones;
    public TextMeshProUGUI mostrarTexto;
    string bashActual;
    public float velEscritura;

    private void Start(){
        textos = new Queue<string>();
    }

    void StartText(){
        textos.Clear();
        foreach(string texto in laptop.listaBash){
            textos.Enqueue(texto);
        }
        mostrarSiguienteTexto();
    }

    void mostrarSiguienteTexto(){
        if( textos.Count <= 0){
            mostrarTexto.text = bashActual;
            return;
        }
        bashActual = textos.Dequeue();
        mostrarTexto.text = bashActual;
        StopAllCoroutines();
        StartCoroutine(escribeTexto(bashActual));
    }

    IEnumerator escribeTexto(string texto){
        mostrarTexto.text = "";
        foreach (char letra in texto.ToCharArray()){
            mostrarTexto.text += letra;
            yield return new WaitForSeconds(velEscritura);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Player")){
            panelIndicaciones.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider collider) {
        if(collider.CompareTag("Player")){
            if(Input.GetKeyDown("e")){
                panelIndicaciones.SetActive(false);
                panelBash.SetActive(true);
                StartText();
            }
        }
    }

    public void SiguienteButton(){
        if(mostrarTexto.text == bashActual)
            mostrarSiguienteTexto();
    }

    public void SalirButton(){
        panelBash.SetActive(false);
    }

    private void OnTriggerExit(Collider collider) {
        if(collider.CompareTag("Player")){
            panelIndicaciones.SetActive(false);
            panelBash.SetActive(false);
        }
    }

}
