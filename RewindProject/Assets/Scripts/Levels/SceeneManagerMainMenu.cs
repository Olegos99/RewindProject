using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceeneManagerMainMenu : MonoBehaviour
{
    public GameObject ContinuePlayingButton;

    public GameObject MainPanel;
    public GameObject Credits;

    private void Start()
    {
        if (SceeneManager.instance.PreviousScene == 0 || PauseMenu.instance.LastLevelComplete)
        {
            ContinuePlayingButton.SetActive(false);
        }
        else
        {
            ContinuePlayingButton.SetActive(true);
        }
        if (!AudioManager.instanse.IsSoundIsPlayingNow("MainTheme"))
        {
            AudioManager.instanse.Play("MainTheme");
        }
    }

    public void ExitAplication()
    {
        Debug.Log("ExitAplication");
            Application.Quit();
    }

    public void ContinuePlaying()
    {
        SceeneManager.instance.ContinuePlaying();
    }

    public void StartNewGame()
    {
        SceeneManager.instance.LoadSceeneNumber(1);
    }

    public void CreditsUI()
    {
        Credits.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void CreditsUIDisable()
    {
        Credits.SetActive(false);
        MainPanel.SetActive(true);
    }
}
