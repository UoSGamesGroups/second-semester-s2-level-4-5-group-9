using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Pause_Controller : MonoBehaviour {

    Canvas canvas;                                      // Gets the pause menu canvas

    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        canvas.enabled = !canvas.enabled;                   // Toggles the menu state
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;       // Toggles time & Stops Update Functions
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);         // Reloads the current scene
        Time.timeScale = 1;       // Sets time back to running normally
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);       // Loads MainMenu
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;       // Toggles time & Stops Update Functions
    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;                // If used in editor it ends play mode
#else                                                       // Otherwise it'll quit the application
        Application.Quit();
#endif
    }
}
