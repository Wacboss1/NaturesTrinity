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
            winScreen.SetActive(true);
        }
        else if (controller.isLose() == true)
        {
            loseScreen.SetActive(true);
        }
    }

    public void startGame()
    {
        print("changing scene");
        SceneManager.LoadScene(1);
    }

    public void restartGame()
    {
        //runs after losing 
    }
}
