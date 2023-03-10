using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : MonoBehaviour
{
    private bool levelFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Ball")
        {
            levelFinished = true;
        }  
    }

    public bool CheckFinishState()
    {
        return levelFinished;
    }

    public void NotFinished()
    {
        levelFinished = false;
    }
}
