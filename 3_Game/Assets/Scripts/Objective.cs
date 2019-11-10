using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;

    public enum objective{ desert, mountain, forest }

    [SerializeField] objective ob;

    Game_Controller controller;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        controller = player.GetComponent<Game_Controller>();
    }
    
    //Triggers when player reaches objective
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Transform otherTransform = collision.gameObject.transform;
            otherTransform.position = new Vector3(x, y, 0);
            switch (ob)
            {
                case objective.desert:
                    controller.completeDesert();
                    break;
                case objective.forest:
                    controller.completeForrest();
                    break;
                case objective.mountain:
                    controller.completeMountain();
                    break;
            }
        }
    }
}
