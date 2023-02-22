using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject ball;
    public int cameraAngle = 20;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);

        transform.rotation = Quaternion.Euler(cameraAngle, ball.transform.rotation.eulerAngles.x, 0);
    }
}
