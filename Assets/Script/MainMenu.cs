using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //declare the scene
    private int optionscene;

    private void Start()
    {
        SpawnPoint.Isfirts = true;
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        //scene change, change the 1 to scene number
        SceneManager.LoadScene(1);
    }

    public void OptionGame()
    {
        SceneManager.LoadScene(optionscene);
    }

    public void ExitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene(0);
    }
}
