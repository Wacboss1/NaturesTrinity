using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float currentSpeed = 1f;
    public float dashSpeed = 10;
    public float dodgetime = 1;
    public float originSpeed;
    public bool canMove = true;

    Game_Controller controller;
    CircleCollider2D[] colliders;

    void Start()
    {
        controller = this.GetComponent<Game_Controller>();
        colliders = this.GetComponents<CircleCollider2D>();

        originSpeed = currentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            move();
            //activates dodge when space is pushed
            if (Input.GetKeyDown("space"))
            {
                dodge();
            }
        }
        //resests speed at end of every frame to prevent double dashing
        resetSpeed();
    }

    private void move()
    {
        float xtranslation = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
        float ytranslation = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

        transform.Translate(xtranslation, ytranslation, 0);
    }

    //dashed the player and makes them immune to damage
    private void dodge()
    {
        currentSpeed += dashSpeed;
        controller.setHitable(false);
        StartCoroutine(controller.recover(dodgetime));
    }

    private void resetSpeed()
    {
        if (currentSpeed > originSpeed && controller.is_hitable == true)
        {
            currentSpeed = originSpeed;
        }
    }

}
