using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    Game_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        controller = gameObject.GetComponent<Game_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHorizontal();
        checkUp();
        checkDown();
        checkMoving();
    }
    private bool isDashing()
    {
        if(controller.is_hitable == false)
        {
            return true;
        }
        return false;
    }
    private bool isMovingLeft()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            return true;
        }
        return false;
    }
    private bool isMovingRight()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            return true;
        }
        return false;
    }

    private bool isMovingUp()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            return true;
        }
        return false;
    }

    private bool isMovingDown()
    {
        if (Input.GetAxis("Vertical") < 0)
        {
            return true;
        }
        return false;
    }

    private bool isNotMoving()
    {
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            return true;
        }
        return false;
    }

    IEnumerator stopRolling()
    {
        yield return new WaitForSeconds(controller.getDodgeTime());
        anim.SetBool("Is_dashing", false);
    }

    private void checkHorizontal()
    {
        if (isMovingLeft() && isDashing())
        {
            sprite.flipX = false;
            anim.SetBool("Is_dashing", true);
            anim.SetBool("Walking_left", true);
            StartCoroutine(stopRolling());
        }
        else if (isMovingRight() && isDashing())
        {
            sprite.flipX = true;
            anim.SetBool("Is_dashing", true);
            anim.SetBool("Walking_left", true);
            StartCoroutine(stopRolling());
        }
        else if (isMovingLeft())
        {
            sprite.flipX = false;
            anim.SetBool("Walking_left", true);
        }
        else if (isMovingRight())
        {
            sprite.flipX = true;
            anim.SetBool("Walking_left", true);
        }
        else
        {
            anim.SetBool("Is_dashing", false);
            anim.SetBool("Walking_left", false);
        }
    }

    private void checkUp()
    {
        if (isMovingUp() && isDashing())
        {
            anim.SetBool("Is_dashing", true);
            anim.SetBool("Walking_up", true);
            StartCoroutine(stopRolling());
        }
        else if (isMovingUp())
        {
            anim.SetBool("Walking_up", true);
        }
        else
        {
            anim.SetBool("Walking_up", false);
        }
    }

    private void checkDown()
    {
        if (isMovingDown() && isDashing())
        {
            anim.SetBool("Is_dashing", true);
            anim.SetBool("Walking_down", true);
            sprite.flipY = true;
            StartCoroutine(stopRolling());
        }
        else if (isMovingDown())
        {
            sprite.flipY = false;
            anim.SetBool("Walking_down", true);
        }
        else
        {
            sprite.flipY = false;
            anim.SetBool("Walking_down", false);
        }
    }

    private void checkMoving()
    {
        if (isNotMoving())
        {
            anim.SetBool("Not_moving", true);
        }
        else
        {
            anim.SetBool("Not_moving", false);
        }
    }
}
