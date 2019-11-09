using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] Type enemyType;

    [SerializeField] Vector2 start;
    [SerializeField] Vector2 finish;

    enum Type { follow, constant };
    GameObject player;
    Transform target;
    Game_Controller controller;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.position = start;
        controller = player.GetComponent<Game_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case Type.follow:
                chase();
                break;
            case Type.constant:
                moveBetween(start, finish);
                break;
        }
    }

    private void chase()
    {
        target = player.GetComponent<Transform>();
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }

    private void moveBetween(Vector2 start, Vector2 finish)
    {
        this.transform.position = Vector2.Lerp(start, finish, Mathf.PingPong(Time.time * speed, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && controller.is_hitable == true)
        {
            controller.is_hitable = false;
            controller.damagePlayer();
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, -.5f);
            StartCoroutine(controller.recover(3));
        }
    }
}
