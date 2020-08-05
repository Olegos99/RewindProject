using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEtoActivate : MonoBehaviour
{
    public GameObject GameObjectToActivate;

    RewindCloneCreation RewindCloneCreation;

    public ButtonTimeUI buttonTimeUI;

    public bool HaveActiveTimeLimit;
    public float TimeLimit;

    public bool AllowPlayerReuseButtonOnCoorutineRuning;


    private bool PlayerCurrentlyInZone = false;
    private bool CloneCurrentlyInZone = false;


    private bool CoorutineIsRunning = false;

    private float time;

    private void Start()
    {
        RewindCloneCreation = RewindCloneCreation.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Press E to activate");
            PlayerCurrentlyInZone = true;
        }
        if (other.name == "RewindClone(Clone)")
        {
            CloneCurrentlyInZone = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            PlayerCurrentlyInZone = false;
        }
        if (other.name == "RewindClone(Clone)")
        {
            CloneCurrentlyInZone = false;
        }
    }

    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.E) && PlayerCurrentlyInZone)
        {
            Activate();
        }
        if(CloneCurrentlyInZone && RewindCloneCreation.CloneIsPressingE)
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (!HaveActiveTimeLimit)
        {
            GameObjectToActivate.SetActive(false);
        }
        else if(!CoorutineIsRunning)
        {
            StartCoroutine(ActivateWithTimeLimit(TimeLimit));
        }
        else if(CoorutineIsRunning && AllowPlayerReuseButtonOnCoorutineRuning)
        {
            //StopCoroutine(ActivateWithTimeLimit(TimeLimit));
            StopAllCoroutines();
            StartCoroutine(ActivateWithTimeLimit(TimeLimit));
            time = TimeLimit;
        }
    }

    IEnumerator ActivateWithTimeLimit(float someTime)
    {
        CoorutineIsRunning = true;
        //GameObjectToActivate.SetActive(false);
        //yield return new WaitForSeconds(someTime);
        //GameObjectToActivate.SetActive(true);

        GameObjectToActivate.SetActive(false);

        float TTTime = someTime;
        time = someTime;
        while (time > 0)
        {
            time -= Time.deltaTime;
            buttonTimeUI.SetTimerUIClocwise(TTTime, time);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        time = 0;
        GameObjectToActivate.SetActive(true);
        CoorutineIsRunning = false;
    }
}
