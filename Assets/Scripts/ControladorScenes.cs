using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorScenes : MonoBehaviour{

    public void CambiarEscena(string nombreEscena){
        SceneManager.LoadScene(nombreEscena);
    }

    public void Salir(){
        Application.Quit();
    }

}
