using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log(lvlShots);
                NextLevel();
                goal.GetComponent<FinishState>().NotFinished();
            }
        }
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

        if (currentLvl > levels.Length - 1)
        {
            EndGame();
        } 

        else 
        {
            currentLvl += 1;
            GameObject.Instantiate(levels[currentLvl]);
            goal = GameObject.FindGameObjectWithTag("Goal");
        }
    }

    void EndGame()
    {
        Debug.Log("End Game");
    }
}
