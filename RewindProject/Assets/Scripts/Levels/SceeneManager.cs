using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceeneManager : MonoBehaviour
{

    public static SceeneManager instance;

    public Scene MainMenu;
    public string[] Levels;

    public int CurrentSceneNumber = 0;
    public int PreviousScene = 0;

    private void Awake()
    {
        if (instance == null)// to check that only one Audio Manager is in the seen
        { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        //CurrentSceneNumber
        foreach (string s in Levels)
        {
            if(s == SceneManager.GetActiveScene().name)
            {
                for(int i = 0; i < Levels.Length; i ++)
                {
                    if(s == Levels[i])
                    {
                        CurrentSceneNumber = i;
                    }
                }
            }
        }



    DontDestroyOnLoad(gameObject);
    }

    public void ExitAplication()
    {
        Debug.Log("ExitAplication");
            Application.Quit();
    }

    public void ContinuePlaying()
    {
        LoadSceeneNumber(PreviousScene);
    }

    public void LoadSceeneNumber(int LevelNumber)
    {
        AudioManager.instanse.StopAllSounds();
        SceneManager.LoadScene(Levels[LevelNumber], LoadSceneMode.Single);
        PreviousScene = CurrentSceneNumber;
        CurrentSceneNumber = LevelNumber;

        //if (CurrentSceneNumber == 0)
        //{
        //    ContinuePlayButtonControll();
        //}
    }


    //void ContinuePlayButtonControll()
    //{
    //    if(ContinuePlayingButton == null)
    //    {
    //        ContinuePlayingButton = GameObject.Find("Continue Playing");
    //    }
    //    if (PreviousScene != 0)
    //    {
    //        ContinuePlayingButton.SetActive(true);
    //    }
    //    else
    //    {
    //        ContinuePlayingButton.SetActive(false);
    //    }
    //}

}
