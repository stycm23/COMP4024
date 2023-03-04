using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float maxPower;
    public float lookSens = 10;
    public Rigidbody ball;

    private float shotPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
                shotPower = 0;
        }
        
        if (ball.velocity.magnitude == 0) 
            {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                shotPower += Input.GetAxis("Mouse Y") * -5f;
                if (shotPower > maxPower) {shotPower = maxPower;}
                if (shotPower < 0) {shotPower = 0;}
                Debug.Log(shotPower);
                
                transform.Rotate(0, lookSens * Input.GetAxis("Mouse X"), 0);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                ball.AddForce(transform.forward * shotPower, ForceMode.Impulse);
            }
        }
    }
}
