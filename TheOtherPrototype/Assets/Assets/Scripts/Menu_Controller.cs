using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;                // If used in editor it ends play mode
#else                                                       // Otherwise it'll quit the application
        Application.Quit();
#endif
    }
}
