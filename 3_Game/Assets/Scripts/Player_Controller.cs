using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 1f;
    public float dashSpeed = 10;

    [SerializeField] float dodgetime = 1;
    [SerializeField] character charact; 

    Game_Controller controller;
    BoxCollider2D[] colliders;
    enum character { goat, armadillo, birb}

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
            useCharacterAbility();
        }
    }

    private void move()
    {
        float xtranslation = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float ytranslation = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(xtranslation, ytranslation, 0);
    }

    private void useCharacterAbility()
    {
        switch (charact)
        {
            case character.armadillo:
                dodge();
                print("dodging");
                break;
            case character.birb:
                print("shooting");
                break;
        }
    }

    //dashed the player and makes them immune to damage
    private void dodge()
    {
        speed += dashSpeed;
        controller.setHitable(false);
        StartCoroutine(controller.recover(dodgetime));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Checks if a smash is possible then excutes it when space is pressed
        if (collision.gameObject.tag == "Smashable" && charact == character.goat)
        {
            if (Input.GetKey("space"))
            {
                collision.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Deals damage to player when the collide with enemy

    }
}
