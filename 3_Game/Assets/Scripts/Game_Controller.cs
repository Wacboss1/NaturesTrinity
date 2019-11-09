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
        if(mountain_isFinished && forrest_isFinished && desert_isFinished)
        {
            print("game is won");
        }
    }
    //TODO monitor how much of the game the player has completed
}
