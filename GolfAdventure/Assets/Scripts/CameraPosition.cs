using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody ballRB;
    public int cameraAngle = 20;
    public float smoothingRate = 10;


    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 velocity = ballRB.velocity;
        //float angle = getAngleFromVelocity(velocity); //Depreciated

        transform.position = ball.transform.position;
    }

    float getAngleFromVelocity(Vector3 velocity) // Depreciated
    {
        double angleRad = Math.Atan2(velocity.x, velocity.z);
        double angleDeg = angleRad * (180 / Math.PI);

        return (float)angleDeg; 
    }
}
