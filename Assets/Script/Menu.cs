using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");//Loads Scene Called StartMenu
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Loads current Scene
    }


    public void QuitGame()
    {
        Application.Quit();// Closes game
    }


}
