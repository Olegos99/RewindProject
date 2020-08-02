using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindCloneCreation : MonoBehaviour
{
    public GameObject RewindClone;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(RewindClone, Player.transform.position, Quaternion.identity);
            Debug.Log("R was pressed");
        }
    }
}
