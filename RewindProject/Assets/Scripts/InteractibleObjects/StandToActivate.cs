using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandToActivate : MonoBehaviour
{
    public GameObject GameObjectToActivate;

    public bool PlayerCurrentlyInZone = false;
    public bool CloneCurrentlyInZone = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
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

    public void ActivationControll(bool Activate)
    {
        if(Activate)
        {
            GameObjectToActivate.SetActive(false);
        }
        else
        {
            GameObjectToActivate.SetActive(true);
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerCurrentlyInZone || CloneCurrentlyInZone && GameObjectToActivate.activeInHierarchy)
        {
            ActivationControll(true);
        }
        else if (!GameObjectToActivate.activeInHierarchy && !PlayerCurrentlyInZone && !CloneCurrentlyInZone)
        {
            ActivationControll(false);
        }
    }
}
