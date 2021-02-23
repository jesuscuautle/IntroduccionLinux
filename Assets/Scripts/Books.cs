using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Books{
    public string nombre;
    [TextArea(5, 15)]
    public string[] textoLibro;
}
