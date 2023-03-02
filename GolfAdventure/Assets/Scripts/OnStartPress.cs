using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartPress : MonoBehaviour
{
    public void PlayGame()
        {
            ScreenManager.LoadScene(ScreenManager.GetActiveScene().buildIndex * 1);
        }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
