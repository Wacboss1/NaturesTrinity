using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    [SerializeField] int health = 1;

    [SerializeField] bool mountain_isFinished = false;
    [SerializeField] bool forrest_isFinished = false;
    [SerializeField] bool desert_isFinished = false;

    public bool is_hitable = true;

    Player_Controller playerscript;
    // Start is called before the first frame update
    void Start()
    {
        playerscript = GameObject.FindWithTag("Player").GetComponent<Player_Controller>();
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
    public bool isWon()
    {
        if (desert_isFinished)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isLose()
    {
        if(health == 0)
        {
            return true;
        }
        return false;
    }

    //Updated the completion of the corresponding level
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

    public void damagePlayer()
    {
        health -= 1;
    }

    public void stopMovement()
    {
        playerscript.canMove = false;
    }

    //changes whether or not the player can be hit/Take damage
    public void setHitable(bool canHit)
    {
        is_hitable = canHit;
    }

    public float getDodgeTime()
    {
        return playerscript.dodgetime;
    }

    //awaits a set period of time before player can get hit again
    public IEnumerator recover(float waittime)
    {

        yield return new WaitForSeconds(waittime);
        //returns speed back to normal
        if (playerscript.currentSpeed >= playerscript.dashSpeed)
        {
            playerscript.currentSpeed -= playerscript.dashSpeed;
        }
        //makes the player able to be hit
        setHitable(true);
    }

}
