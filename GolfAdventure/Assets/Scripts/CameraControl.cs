using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float lookSens = 10;
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
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
}
