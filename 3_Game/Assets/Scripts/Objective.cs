using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField] float x = 0f;
    [SerializeField] float y = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform transform = collision.gameObject.transform;
        transform.position = new Vector3(x, y, 0);
    }
}
