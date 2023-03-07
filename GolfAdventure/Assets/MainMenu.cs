using System.Collections;
using System.Collections.Generic;
using UnityEngine;
usign UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour { 


    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildinex + 1);
    }
    
    public void QuitGame ()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
