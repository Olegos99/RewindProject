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

        DontDestroyOnLoad(gameObject);
    }



    public void LoadSceeneNumber(int LevelNumber)
    {
        SceneManager.LoadScene(Levels[LevelNumber], LoadSceneMode.Single);
        CurrentSceneNumber = LevelNumber;
    }

}
