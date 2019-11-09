using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] type enemyType;
    enum type { follow, constant };
    GameObject player;
    Transform target;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case type.follow:
                chase();
                break;
            case type.constant:
                //TODO make the 
                break;
        }
    }

    private void chase()
    {
        target = player.GetComponent<Transform>();
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
    }
}
