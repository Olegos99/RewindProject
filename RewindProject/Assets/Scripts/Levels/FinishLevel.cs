using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    SceeneManager SceeneManager;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            FinishLevelFunction();
        }
    }

    private void Start()
    {
        SceeneManager = SceeneManager.instance;
    }


    private void FinishLevelFunction()
    {
        Debug.Log("Level is Finished");
        //some sound

        // animation on level finished + particle system

        // SceeneManager next level load
        Debug.Log("Trying to open Scene number " + SceeneManager.CurrentSceneNumber + 1);
        SceeneManager.LoadSceeneNumber(SceeneManager.CurrentSceneNumber + 1); // loading nextSceene

    }
}
