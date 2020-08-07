using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    SceeneManager SceeneManager;

    bool FinishLevelFunctionCoorutineIsRuning = false;

    float Time = 2f;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            if (SceeneManager.instance.CurrentSceneNumber == 3)
            {
                PauseMenu.instance.WiningTheGame();
            }
        }
        if (other.name == "Player" && !FinishLevelFunctionCoorutineIsRuning)
        {
            // FinishLevelFunction();
            StartCoroutine("FinishLevelFunction");
        }
    }

    private void Start()
    {
        SceeneManager = SceeneManager.instance;
    }


    //private void FinishLevelFunction()
    //{
    //    Debug.Log("Level is Finished");
    //    //some sound

    //    // animation on level finished + particle system

    //    // SceeneManager next level load
    //    Debug.Log("Trying to open Scene number " + SceeneManager.CurrentSceneNumber + 1);


    //    AudioManager.instanse.Play("Wow");
    //    SceeneManager.LoadSceeneNumber(SceeneManager.CurrentSceneNumber + 1); // loading nextSceene

    //}



    IEnumerator FinishLevelFunction()
    {
        FinishLevelFunctionCoorutineIsRuning = true;

        float time = Time;



        CameraMovment.instance.ResetCameraTargetPositionToDeathView();

        //player partical system
        AudioManager.instanse.StopAllSounds();
        MovementControl.instance.MovementEnabled = false;
        ParticleSystemController.instance.ActivateParticleSystem(1, time);
        AudioManager.instanse.Play("Wow");
        yield return new WaitForSeconds(time);

        MovementControl.instance.MovementEnabled = true;
        FinishLevelFunctionCoorutineIsRuning = false;
        SceeneManager.LoadSceeneNumber(SceeneManager.CurrentSceneNumber + 1); // loading nextSceene
    }
}
