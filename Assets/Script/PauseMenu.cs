using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Ispaused = false;

    [SerializeField]
    public GameObject PausedUI, PauseButton;

    public void Resume()
    {
        Ispaused = false;
        PausedUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Paused()
    {
        Ispaused = true;
        PausedUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
