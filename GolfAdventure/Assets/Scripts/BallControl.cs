using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float maxPower;
    public float lookSens = 10;
    public Rigidbody ball;
    public GameObject powerVisual;
    public GameObject manager;
    public GameObject goal;

    private float shotPower = 0;

    // Start is called before the first frame update
    void Start()
    {
        ConnectManager();
        NextLevel();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            transform.position = ball.transform.position;
            ShotControl();
            CameraControl();
        } else {NextLevel();}
    }

    void CameraControl()
    {
        if (Input.GetKeyDown(KeyCode.R) && !Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 planarGoal = goal.transform.position;
            planarGoal.y = transform.position.y;
            transform.LookAt(planarGoal);
        }

        if (Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse0)) 
        {
            Debug.Log("RMB Pressed");
            float rot = Input.GetAxis("Mouse X");
            transform.Rotate(0.0f, lookSens * Input.GetAxis("Mouse X"), 0.0f, Space.Self);
        }
    }

    void ShotControl() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
                shotPower = 0;
        }
        
        if (ball.velocity.magnitude == 0) 
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                shotPower += Input.GetAxis("Mouse Y") * -2.5f;
                if (shotPower > maxPower) {shotPower = maxPower;}
                if (shotPower < 0) {shotPower = 0;}
                
                transform.Rotate(0, lookSens * Input.GetAxis("Mouse X"), 0);
                UpdateVisual(shotPower);
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                UpdateVisual(0f);
                ball.AddForce(transform.forward * shotPower, ForceMode.Impulse);

                manager.GetComponent<GameManager>().AddShot();
            }
        }    
    }

    void UpdateVisual(float power)
    {
        powerVisual.transform.localScale = new Vector3(1, 1, power/maxPower);
        powerVisual.GetComponentInChildren<Renderer>().material.color = new Color((power/maxPower)*1, 0, 0);
    }

    void ConnectManager()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");

        if (manager == null)
        {
            Debug.LogError("Game manager could not be found");
        }
    }

    void ConnectBall()
    {
        GameObject ballGO = GameObject.FindGameObjectWithTag("Ball");

        if (ballGO == null)
        {
            Debug.LogError("Ball object could not be found");
        }

        ball = ballGO.GetComponent<Rigidbody>();
    }

    void ConnectGoal()
    {
        goal = GameObject.FindGameObjectWithTag("Goal");
    }

    public void NextLevel()
    {
        ConnectBall();
        ConnectGoal();
    }
}
