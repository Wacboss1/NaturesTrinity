using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui_Controller : MonoBehaviour
{
    Game_Controller controller;

    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<Game_Controller>();
    }

    private void Update()
    {
        if(controller.isWon() == true)
        {
            controller.stopMovement();
            winScreen.SetActive(true);
            StartCoroutine(reset());
        }
        else if (controller.isLose() == true)
        {
            controller.stopMovement();
            loseScreen.SetActive(true);
            StartCoroutine(reset());
        }
    }

    public void startGame()
    {
        print("changing scene");
        SceneManager.LoadScene(1);
    }

    IEnumerator reset()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
