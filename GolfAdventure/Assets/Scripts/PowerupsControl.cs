using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsControl : MonoBehaviour
{
    public float speedIncrease;
    //public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("trigger");
        if (other.gameObject.tag == "SpeedBoost")
        {
            Debug.Log("SpeedBoost");
            SpeedBoost();
        }
    }

    private void SpeedBoost()
    {
        Rigidbody ballRB = this.GetComponent<Rigidbody>();
        ballRB.AddForce(Vector3.Normalize(ballRB.velocity) * speedIncrease, ForceMode.Impulse);
    }
}
