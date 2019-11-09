using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] int health = 3;

    [SerializeField] bool mountain_isFinished = false;
    [SerializeField] bool forrest_isFinished = false;
    [SerializeField] bool desert_isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if all the objectives have been aquired
        if (isWon())
        {
            print("game is won");
        }
    }
    //TODO monitor how much of the game the player has completed

    //returns true if all the objectives have been aquired
    private bool isWon()
    {
        if (mountain_isFinished && forrest_isFinished && desert_isFinished)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void completeMountain()
    {
        mountain_isFinished = true;
    }
    public void completeForrest()
    {
        forrest_isFinished = true;
    }
    public void completeDesert()
    {
        desert_isFinished = true;
    }


}
