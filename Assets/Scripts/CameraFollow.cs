using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;


    void LateUpdate() {
        
        // Vector3 desiredPosition = player.position + offset;
        // Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;

        transform.position = player.position + offset;

        //Debug.Log("Camera Position: " + transform.position);
        //Debug.Log("Target Position: " + (player.position + offset));
    }
}
