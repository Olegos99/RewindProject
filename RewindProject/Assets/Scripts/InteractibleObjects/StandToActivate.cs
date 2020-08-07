using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandToActivate : MonoBehaviour
{
    public GameObject GameObjectToActivate;

    public bool DeactivateGameObject = false;

    public bool PlayerCurrentlyInZone = false;
    public bool CloneCurrentlyInZone = false;

    private void Start()
    {
        if (DeactivateGameObject)
        {
            GameObjectToActivate.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
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
            if(!DeactivateGameObject)
            {
                GameObjectToActivate.SetActive(false);
            }
            else
            {
                GameObjectToActivate.SetActive(true);
            }
        }
        else
        {
            if (!DeactivateGameObject)
            {
                GameObjectToActivate.SetActive(true);
            }
            else
            {
                GameObjectToActivate.SetActive(false);
            }
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if (CloneCurrentlyInZone == true)
        {
            if (!RewindCloneManager.instance)
            {
                CloneCurrentlyInZone = false;
            }
        }

        if (PlayerCurrentlyInZone == true)
        {
            //if (PlayerManager.instance.transform.position == PlayerManager.instance.StartingPosition)
            if (Vector3.Distance(PlayerManager.instance.transform.position, transform.position) > 5f)
            {
                PlayerCurrentlyInZone = false;
            }
        }


        if (!DeactivateGameObject)
        {
            if (PlayerCurrentlyInZone || CloneCurrentlyInZone && GameObjectToActivate.activeInHierarchy)
            {
                ActivationControll(true);
            }
            if (!GameObjectToActivate.activeInHierarchy && !PlayerCurrentlyInZone && !CloneCurrentlyInZone)
            {
                ActivationControll(false);
            }
        }
        else
        {
            if (PlayerCurrentlyInZone || CloneCurrentlyInZone && !GameObjectToActivate.activeInHierarchy)
            {
                ActivationControll(true);
            }
            if (GameObjectToActivate.activeInHierarchy && !PlayerCurrentlyInZone && !CloneCurrentlyInZone)
            {
                ActivationControll(false);
            }
        }

    }
}
