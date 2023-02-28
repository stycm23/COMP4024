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
        float angle = getAngleFromVelocity(velocity);

        transform.position = ball.transform.position;
        //  transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        /*float change = 0;
        if ((transform.rotation.eulerAngles.y > angle + 0.5) | (transform.rotation.eulerAngles.y < angle - 0.5))
        {
            print("Rotating");
            float diff = angle - transform.rotation.eulerAngles.y;
            change = diff/smoothingRate;

            if (change > 0) {change = 0-change;}
        }
        print(change);
        transform.Rotate(0.0f, change, 0.0f, Space.World);*/
        //transform.rotation = Quaternion.Euler(cameraAngle, angle, 0);
    }

    float getAngleFromVelocity(Vector3 velocity)
    {
        double angleRad = Math.Atan2(velocity.x, velocity.z);
        double angleDeg = angleRad * (180 / Math.PI);

        return (float)angleDeg;
    }
}
