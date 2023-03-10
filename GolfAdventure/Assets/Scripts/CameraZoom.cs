using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public Transform ball;
    public Transform rig;
    public Transform playerCam;
    public Vector3 defaultCamPos;
    private float defaultCamDis;

    // Start is called before the first frame update
    void Start()
    {
        playerCam.position = defaultCamPos;
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    void FixedUpdate()
    {
        if (ball != null)
        {
            transform.LookAt(rig);
            transform.position = playerCam.position;

            RaycastHit hit;
            Physics.Raycast(transform.position, (ball.position-transform.position), out hit, Vector3.Distance(transform.position, ball.position));
            
            if (hit.transform == ball)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                Debug.Log("Can be seen");
                //zoomCamera(true);
            }
            else 
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Can't be seen");
                //zoomCamera(false);
            }
        }

    }

    void zoomCamera(bool seen)
    {
        if(seen)
        {
            if(Vector3.Distance(playerCam.position, ball.position) != defaultCamDis)
            {
                transform.Translate(0, 0, defaultCamDis);
            }
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
