using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogoTrish : MonoBehaviour
{

    public Dialogue dialogue;
    Queue<string> oraciones;
    public GameObject panelDialogos;
    public TextMeshProUGUI mostrarTexto;
    string oracionActual;
    public float velEscritura;

    void Start()
    {
        oraciones = new Queue<string>();
    }

    void StartDialogue()
    {
        oraciones.Clear();
        foreach (string oracion in dialogue.listaOraciones)
        {
            oraciones.Enqueue(oracion);
        }
        mostarSiguienteOracion();
    }

    public void mostarSiguienteOracion()
    {
        if (oraciones.Count <= 0)
        {
            mostrarTexto.text = oracionActual;
            return;
        }
        oracionActual = oraciones.Dequeue();
        mostrarTexto.text = oracionActual;
        StopAllCoroutines();
        StartCoroutine(escribeOracion(oracionActual));
    }

    IEnumerator escribeOracion(string oracion)
    {
        mostrarTexto.text = "";
        foreach (char letra in oracion.ToCharArray())
        {
            mostrarTexto.text += letra;
            yield return new WaitForSeconds(velEscritura);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            panelDialogos.SetActive(true);
            StartDialogue();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return) && mostrarTexto.text == oracionActual)
            {
                mostarSiguienteOracion();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            panelDialogos.SetActive(false);
        }
    }

}
