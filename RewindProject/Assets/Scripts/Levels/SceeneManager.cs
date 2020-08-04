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
    foreach(string s in Levels)
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



    public void LoadSceeneNumber(int LevelNumber)
    {
        AudioManager.instanse.StopAllSounds();


        SceneManager.LoadScene(Levels[LevelNumber], LoadSceneMode.Single);
        CurrentSceneNumber = LevelNumber;
    }

}
