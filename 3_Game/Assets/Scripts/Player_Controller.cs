using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 1f;
    public float dashSpeed = 10;
    public float dodgetime = 1;

    Game_Controller controller;
    BoxCollider2D[] colliders;

    void Start()
    {
        controller = this.GetComponent<Game_Controller>();
        colliders = this.GetComponents<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if (Input.GetKeyDown("space"))
        {
            dodge();
        }
    }

    private void move()
    {
        float xtranslation = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float ytranslation = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(xtranslation, ytranslation, 0);
    }

    //dashed the player and makes them immune to damage
    private void dodge()
    {
        speed += dashSpeed;
        controller.setHitable(false);
        StartCoroutine(controller.recover(dodgetime));
    }

}
