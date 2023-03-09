using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject ball;


    void Start()
    {

    }

    void FixedUpdate()
    {
        //float angle = getAngleFromVelocity(velocity); //Depreciated
        transform.position = ball.transform.position;
    }
}
