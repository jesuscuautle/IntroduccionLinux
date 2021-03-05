using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ATMManager : MonoBehaviour{

    public ATM atm;
    Queue<string> textos;
    public GameObject panelATM;
    public GameObject panelIndicaciones;
    public TextMeshProUGUI mostrarTexto;
    string textoActual;
    string nombreEscena;
    public float velTexto;
    string contraseña;
    string contraseñaUsuario;
    public Text signivel;
    public GameObject Door_Left_01;
    public GameObject Door_Left_02;
    

    private void Start() {
        textos = new Queue<string>();
        contraseña = "1978CUNIX";
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



   public void CambiarEscena(string nombreEscena)
    {
       contraseñaUsuario = signivel.text;
       if (contraseñaUsuario == contraseña)
       {
           SceneManager.LoadScene(nombreEscena);
       }
       
    }
}