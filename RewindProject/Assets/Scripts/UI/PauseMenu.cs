using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    public GameObject Hint;

    public bool TheGameIsPaused = false;

    public static PauseMenu instance;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !TheGameIsPaused)
        {
            TheGameIsPaused = true;
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && TheGameIsPaused)
        {
            TheGameIsPaused = false;
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        AudioManager.instanse.PauseAllSounds();
        PauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioManager.instanse.ResumePausedSounds();
        Hint.SetActive(false);
        PauseMenuUI.SetActive(false);
    }

    public void GoToMainMenu()
    {
        ResumeGame();
        SceeneManager.instance.LoadSceeneNumber(0);
    }

    public void ActivateHint()
    {
        Time.timeScale = 0;
        AudioManager.instanse.PauseAllSounds();
        Hint.SetActive(true);
    }
}
