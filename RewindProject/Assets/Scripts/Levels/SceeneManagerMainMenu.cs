using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceeneManagerMainMenu : MonoBehaviour
{
    public GameObject ContinuePlayingButton;

    private void Start()
    {
        if (SceeneManager.instance.PreviousScene == 0)
        {
            ContinuePlayingButton.SetActive(false);
        }
        else
        {
            ContinuePlayingButton.SetActive(true);
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
}
