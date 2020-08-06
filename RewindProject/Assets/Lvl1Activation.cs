using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Activation : MonoBehaviour
{
    public bool PlayerCurrentlyInZone = false;
    public GameObject Boss;

    public bool Activate01 = false;
    public bool Activate02 = false;

    bool WasActivatedOnce = false;


    public static Lvl1Activation instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (Activate01)
        //{
        //    if (other.name == "Player" && !HintWasActivatedOnce)
        //    {
        //        PlayerCurrentlyInZone = true;
        //        Boss.GetComponent<Animator>().SetTrigger("Lvl1activation01");
        //    }
        //}

        if (Activate02)
        {
            if (other.name == "Player" && !WasActivatedOnce)
            {
                PlayerCurrentlyInZone = true;
                PauseMenu.instance.ActivateHint();
                Boss.GetComponent<Animator>().SetTrigger("Lvl1activation02");
                WasActivatedOnce = true;
            }
        }

    }

    public void Reset()
    {
         WasActivatedOnce = false;
    }
}
