using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour
{
    public Transform Fire;
    public GameObject Bala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bala, Fire.position, Quaternion.identity);
        }

    }
}
