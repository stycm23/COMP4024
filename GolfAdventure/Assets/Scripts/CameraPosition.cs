using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject ball;
    public Rigidbody ballRB;
    public int cameraAngle = 20;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = ballRB.velocity;
        float angle = getAngleFromVelocity(velocity);

        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
        
        transform.rotation = Quaternion.Euler(cameraAngle, angle, 0);
    }

    float getAngleFromVelocity(Vector3 velocity)
    {
        double angleRad = Math.Atan2(velocity.x, velocity.z);
        double angleDeg = angleRad * (180 / Math.PI);

        print(angleDeg);
        return (float)angleDeg;
    }
}
