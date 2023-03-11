using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject goal;
    public GameObject cameraRig;

    int currentLvl = -1;
    int totalShots = 0;
    int lvlShots = 0;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        NextLevel();

        GameObject.Instantiate(cameraRig);
    }

    // Update is called once per frame
    void Update()
    {
        if (goal != null)
        {
            if(goal.GetComponent<FinishState>().CheckFinishState())
            {
                goal.GetComponent<FinishState>().NotFinished();
                Debug.Log(lvlShots);
                NextLevel();
            }
        } else {goal = GameObject.FindGameObjectWithTag("Goal");}
    }

    // Add extra shot
    public void AddShot()
    {
        lvlShots += 1;
        Debug.Log(lvlShots);
    }

    // Load Next level of the game and reset variables
    void NextLevel()
    {
        totalShots += lvlShots;
        lvlShots = 0;

        if (currentLvl >= 0)
        {
            GameObject.Destroy(GameObject.FindGameObjectWithTag("Level"));
        }

        currentLvl += 1;

        if (currentLvl > levels.Length - 1)
        {
            EndGame();
        } 
        else 
        {
            GameObject.Instantiate(levels[currentLvl]);
            goal = GameObject.FindGameObjectWithTag("Goal");
        }
    }

    void EndGame()
    {
        Debug.Log("End Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
