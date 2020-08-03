using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEtoActivate : MonoBehaviour
{
    public GameObject GameObjectToActivate;

    public RewindCloneCreation RewindCloneCreation;

    public bool HaveActiveTimeLimit;
    public float TimeLimit;


    public bool PlayerCurrentlyInZone = false;
    public bool CloneCurrentlyInZone = false;


    private bool CoorutineIsRunning = false;

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
    }

    IEnumerator ActivateWithTimeLimit(float someTime)
    {
        CoorutineIsRunning = true;
        GameObjectToActivate.SetActive(false);
        yield return new WaitForSeconds(someTime);
        GameObjectToActivate.SetActive(true);
        CoorutineIsRunning = false;
    }
}
