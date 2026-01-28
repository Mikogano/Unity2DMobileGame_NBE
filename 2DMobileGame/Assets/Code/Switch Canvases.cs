using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryCanvasManager : MonoBehaviour
{
    public GameObject newCanvasGameObject; // Drag your new Canvas GameObject here in the Inspector
    public GameObject mainCanvasGameObject; //this is our current canvas, aka, whatever canvas we put this code on
    public string levelToLoad;
    public void OpenNewCanvas()
    {
        if (newCanvasGameObject != null)
        {
            //pause the game
            Time.timeScale = 0;
            //show our pause menu canvas
            newCanvasGameObject.SetActive(true);
        }
        if (mainCanvasGameObject != null)
        {
            mainCanvasGameObject.SetActive(false); // Hide the main canvas
        }
    }
    public void OpenOldCanvas()
    {
        if (newCanvasGameObject != null)
        {
            //pause the game
            Time.timeScale = 1;
            //show our pause menu canvas
            newCanvasGameObject.SetActive(true);
        }
        if (mainCanvasGameObject != null)
        {
            mainCanvasGameObject.SetActive(false); // Hide the main canvas
        }
    }
    public void SwitchScenes()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
