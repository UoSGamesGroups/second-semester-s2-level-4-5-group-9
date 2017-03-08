using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour {

    public void LoadGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
