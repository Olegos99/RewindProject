using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savezone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (PlayerManager.instance.StartingPosition != transform.position)
            {
                PlayerManager.instance.StartingPosition = transform.position;
            }
        }
    }
}
