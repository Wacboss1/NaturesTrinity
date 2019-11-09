using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        float xtranslation = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float ytranslation = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(xtranslation,ytranslation, 0);
    }
}
