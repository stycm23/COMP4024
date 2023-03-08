using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float maxPower;
    public float lookSens = 10;
    public Rigidbody ball;
    public GameObject powerVisual;

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
                
                transform.Rotate(0, lookSens * Input.GetAxis("Mouse X"), 0);
                UpdateVisual(shotPower);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                UpdateVisual(0f);
                ball.AddForce(transform.forward * shotPower, ForceMode.Impulse);
            }
        }
    }

    void UpdateVisual(float power)
    {
        powerVisual.transform.localScale = new Vector3(1, 1, power/100);
        powerVisual.GetComponentInChildren<Renderer>().material.color = new Color((power/100)*1, 0, 0);
    }
}
