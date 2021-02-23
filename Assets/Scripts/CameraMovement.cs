using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour{

    public Transform player;
    public Vector3 CamOffset;
    [Range(0.1f, 1.0f)]
    public float smoothFactor = 0.1f;

    public bool rotacionActive = true;
    public float velRotacion = 5.0f;

    public bool lookAtPlayer = false;

    void Start(){
        CamOffset = transform.position-player.position;
    }

    void FixedUpdate(){

        if(rotacionActive){
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*velRotacion, Vector3.up);
            CamOffset= camTurnAngle*CamOffset;
        }
        Vector3 newPos = player.position + CamOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if(lookAtPlayer || rotacionActive){
            transform.LookAt(player);
        }
    }

}
