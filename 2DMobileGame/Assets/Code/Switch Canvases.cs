using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryCanvasManager : MonoBehaviour
{
    public GameObject newCanvasGameObject; // Drag your new Canvas GameObject here in the Inspector
    public GameObject secondCanvasGameObject;
    public GameObject mainCanvasGameObject; //this is our current canvas, aka, whatever canvas we put this code on
    public string levelToLoad;
    public string levelToLoad2;
    public string levelToLoad3;
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
    public void OpenSecondCanvas()
    {
        if (secondCanvasGameObject != null)
        {
            //show our pause menu canvas
            secondCanvasGameObject.SetActive(true);
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
    public void SwitchScenes2()
    {
        SceneManager.LoadScene(levelToLoad2);
    }
    public void SwitchScenes3()
    {
        SceneManager.LoadScene(levelToLoad3);
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
