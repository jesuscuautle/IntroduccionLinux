using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    private Rigidbody Myrb;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        Myrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Myrb.velocity = new Vector3(0, 0, +speed);
    }
}
