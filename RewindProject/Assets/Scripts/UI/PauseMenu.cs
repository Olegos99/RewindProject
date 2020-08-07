using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public GameObject MainMenuExplanationUI;

    public GameObject FirstScreenExplanation;
    public GameObject WiningTheGameScreenExplanation;

    public GameObject HintMenu;
    public GameObject[] Hints;
    public bool[] HintsActivated;

    public bool LastLevelComplete = false;

    public bool TheGameIsPaused = false;

    

    public static PauseMenu instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LastLevelComplete = false;
        if (SceeneManager.instance.CurrentSceneNumber == 1)
        {
            PauseGame();
            FirstScreenExplanation.SetActive(true);
        }
        HintsActivated = new bool[Hints.Length];
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
        MovementControl.instance.MovementEnabled = false;
        PauseMenuUI.SetActive(true);
      
    }

    public void ResumeGame()
    {
        MovementControl.instance.MovementEnabled = true;
        Time.timeScale = 1;
        AudioManager.instanse.ResumePausedSounds();

        if(FirstScreenExplanation)
        {
            FirstScreenExplanation.SetActive(false);
        }

        if (HintMenu)
        {
            for(int i =0; i<Hints.Length; i++)
            {
                Hints[i].SetActive(false);
            }
            HintMenu.SetActive(false);
        }
        PauseMenuUI.SetActive(false);
    }

    public void GoToMainMenu()
    {
        MainMenuExplanationUI.SetActive(false);
        ResumeGame();
        SceeneManager.instance.LoadSceeneNumber(0);
    }

    public void ActivateHint(int i)
    {
        if (HintsActivated[i] != true)
        {
            Time.timeScale = 0;
            AudioManager.instanse.PauseAllSounds();
            MovementControl.instance.MovementEnabled = false;
            HintMenu.SetActive(true);
            Hints[i].SetActive(true);
            HintsActivated[i] = true;
        }
    }

    public void MainMenuExplanation()
    {
        MainMenuExplanationUI.SetActive(true);
    }

    public void MainMenuExplanationCancel()
    {
        MainMenuExplanationUI.SetActive(false);
    }

    public void WiningTheGame()
    {
        LastLevelComplete = true;
        PauseGame();
        WiningTheGameScreenExplanation.SetActive(true);
    }


}
