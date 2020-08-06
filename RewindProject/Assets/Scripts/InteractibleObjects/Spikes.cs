using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<PlayerManager>().DeadFromSpikes = true;
        }
    }
}
